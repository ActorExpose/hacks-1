package main

import (
  "bytes"
  "bufio"
  "encoding/json"
  "encoding/csv"
  "net/http"
  "os"
  "sync"
  "fmt"
)

type PhishUrls struct {
  URL string `json:"url"`
}

type fetchFn func() ([]PhishUrls, error)

func main() {

  fetchFns := []fetchFn{
    getPhishTankURLs,
    getOpenPhishURLs,
    getNewLinksToday,
    getPhishStatsInfo,
  } 
  
  purls := make(chan PhishUrls)
  
  var wg sync.WaitGroup
  for _, fn := range fetchFns {
    wg.Add(1)
    fetch := fn
    go func() {
      defer wg.Done()
      resp, err := fetch()
      if err != nil {
        return
      }
      for _, r := range resp {
        purls <- r
      }
    }()
  }

  go func() {
    wg.Wait()
    close(purls)
  }()

  for w := range purls {
    fmt.Println(w.URL)
  }

} 

func getOpenPhishURLs() ([]PhishUrls, error) {
  pturl := "https://openphish.com/feed.txt"

  res, err := http.Get(pturl)
  if err != nil {
    return []PhishUrls{}, err
  }

  defer res.Body.Close()
  sc := bufio.NewScanner(res.Body)

  out := make([]PhishUrls, 0)

  for sc.Scan() {   
    out = append(out, PhishUrls{URL: sc.Text()})
  }
  return out, nil
}

func getPhishTankURLs() ([]PhishUrls, error) {

  pturl := "http://data.phishtank.com/data/online-valid.json"

  apiKey := os.Getenv("PT_API_KEY")
  if apiKey != "" {
    pturl = fmt.Sprintf("http://data.phishtank.com/data/%s/online-valid.json", apiKey)
  }

  resp, err := http.Get(pturl)
  if err != nil {
    return []PhishUrls{}, err
  }

  defer resp.Body.Close()

  var urls []PhishUrls
  buf := new(bytes.Buffer)
  buf.ReadFrom(resp.Body)
  respByte := buf.Bytes()
  if err := json.Unmarshal(respByte, &urls); err != nil {
    return []PhishUrls{}, err
  }
  return urls, nil
}

func getNewLinksToday() ([]PhishUrls, error) {
  pturl := "https://raw.githubusercontent.com/mitchellkrogza/Phishing.Database/master/phishing-links-NEW-today.txt"

  res, err := http.Get(pturl)
  if err != nil {
    return []PhishUrls{}, err
  }

  defer res.Body.Close()
  sc := bufio.NewScanner(res.Body)

  out := make([]PhishUrls, 0)

  for sc.Scan() {   
    out = append(out, PhishUrls{URL: sc.Text()})
  }
  return out, nil
}

func getPhishStatsInfo() ([]PhishUrls, error) {
  pturl := "https://phishstats.info/phish_score.csv"
  out := make([]PhishUrls, 0)
  
  res, err := http.Get(pturl)
  if err != nil {
    return []PhishUrls{}, err
  }

  defer res.Body.Close()
  reader := csv.NewReader(res.Body)
  reader.Comma = ','
  reader.Comment = '#'
  data, err := reader.ReadAll()
  if err != nil {
    return []PhishUrls{}, err
  }

  for _, row := range data {
    out = append(out, PhishUrls{URL: row[2]})
  }
  return out, nil
}