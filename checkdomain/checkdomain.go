package main

import (
   "io/ioutil"
   "log"
   "bufio"
   "os"
   "net/http"
   "strings"
)

func main(){

   API_KEY := os.Getenv("MASHAPE_KEY")
   C2_FILE := os.Args[1]

   file, err := os.Open(C2_FILE)
    if err != nil {
        log.Fatal(err)
    }
    defer file.Close()

    scanner := bufio.NewScanner(file)

    for scanner.Scan() {

      c2 := scanner.Text()

      resp, err := http.Get("https://domainr.p.rapidapi.com/v2/status?mashape-key=" + API_KEY + "&domain=" + c2)

      if err != nil {
         log.Fatalln(err)
      }

      body, err := ioutil.ReadAll(resp.Body)
      if err != nil {
         log.Fatalln(err)
      }

      // only output domains that are not active
      sb := string(body)
      if strings.Contains(sb,"inactive") {
         log.Printf(sb)   
      }
       
    }

    if err := scanner.Err(); err != nil {
        log.Fatal(err)
    }

}  