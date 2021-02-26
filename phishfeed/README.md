# phishfeed

Gets a list of Phishing URLs from disparate sources and outputs to stdout

## Install

```
▶ go get -u github.com/cybercdh/hacks/phishfeed
```

## Usage

```
▶ phishfeed

Usage: phishfeed

Useful to pipe into other programs, such as

$ phishfeed | kitphishr 

```

## Sources

Reads recent Phishing URL data from the following sources

* https://openphish.com/feed.txt
* http://data.phishtank.com/data/online-valid.json
* https://raw.githubusercontent.com/mitchellkrogza/Phishing.Database/master/phishing-links-NEW-today.txt
* https://phishstats.info/phish_score.csv


## Pull Requests

Please submit a PR if you have additional sources