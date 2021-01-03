#!/bin/sh
# Ta-daaaaa! key0=65a101b7, key1=40d2eb72, key2=2f98b039
PKEXTRACT=/usr/local/Cellar/pkcrack/1.2.2/bin/extract

FWNAME=$1

echo "Provided update name: $FWNAME"

TEMP_ZIP=$FWNAME_temp.zip

zip -9 $TEMP_ZIP $FWNAME.conf
$PKEXTRACT $TEMP_ZIP $FWNAME.conf $FWNAME.plaintext
rm $TEMP_ZIP

pkcrack -C $FWNAME.bin -c db/etc/zyxel/ftp/conf/system-default.conf -p $FWNAME.plaintext -d cracked.zip -a

