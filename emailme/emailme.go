package main

import (
  "net/smtp"
  "os"
  "strings"
  "fmt"
)

func main() {
  bodytext := os.Args[1]
  send(bodytext)
}

func send(body string) {
  to := []string{"recipient@email.com"}
  toHeader := strings.Join(to, ",")
  from := "your@email.com"
  pass := "some_password" // app specific password

  msg := "From: " + from + "\n" +
    "To: " + toHeader + "\n" +
    "Subject: You wanted to look into this further...\n\n" +
    body

  err := smtp.SendMail("smtp.example.com:587",
    smtp.PlainAuth("", from, pass, "smtp.example.com"),
    from, to, []byte(msg))

  if err != nil {
    fmt.Printf("smtp error: %s", err)
    return
  }
}