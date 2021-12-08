#!/bin/bash

exec 8<>/dev/udp/$1/60001

if(($?!=0));then
    echo "Open UDP error!"
    exit 1;
fi

echo -en '\x30\x30'>&8

cat<&8
exec 8<&-
exec 8>&-
