#!/bin/sh
PKEXTRACT=/usr/local/Cellar/pkcrack/1.2.2/bin/extract

FWNAME=$1
TEMP_ZIP=$FWNAME_temp.zip

zip -9 $TEMP_ZIP $FWNAME.conf
$PKEXTRACT $TEMP_ZIP $FWNAME.conf $FWNAME.plaintext
rm $TEMP_ZIP

pkcrack -C $FWNAME.bin -c db/etc/zyxel/ftp/conf/system-default.conf -p $FWNAME.plaintext -d cracked.zip -a