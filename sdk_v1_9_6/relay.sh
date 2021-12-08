#!/bin/bash

function usage
{
	echo "usage "
	echo "	: on"
	echo "	: off   ./relay.sh 192.168.1.100 on 1"
	echo "	: relay 1~8(channel)/X(All)   ./relay.sh 192.168.1.100 on 1~8/X"
}

function relay_on
{
	case "$3" in
		1)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x31' > /dev/udp/$1/60001
			else
                echo -en '\x31\x31' > /dev/udp/$1/60001
			fi
			;;
		2)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x32' > /dev/udp/$1/60001
			else
                echo -en '\x31\x32' > /dev/udp/$1/60001
			fi
			;;
		3)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x33' > /dev/udp/$1/60001
			else
                echo -en '\x31\x33' > /dev/udp/$1/60001
			fi
			;;
		4)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x34' > /dev/udp/$1/60001
			else
                echo -en '\x31\x34' > /dev/udp/$1/60001
			fi
			;;
		5)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x35' > /dev/udp/$1/60001
			else
                echo -en '\x31\x35' > /dev/udp/$1/60001
			fi
			;;
		6)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x36' > /dev/udp/$1/60001
			else
                echo -en '\x31\x36' > /dev/udp/$1/60001
			fi
			;;
		7)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x37' > /dev/udp/$1/60001
			else
                echo -en '\x31\x37' > /dev/udp/$1/60001
			fi
			;;
		8)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x38' > /dev/udp/$1/60001
			else
                echo -en '\x31\x38' > /dev/udp/$1/60001
			fi
			;;
		X)
            if [ $2 -eq 0 ];then
                echo -en '\x32\x58' > /dev/udp/$1/60001
			else
                echo -en '\x31\x58' > /dev/udp/$1/60001
			fi
			;;
		*)
			usage
			;;
	esac
}

#---------------------------------
#main
#---------------------------------
if [ $# -eq 0 ];then
	usage
else
	case "$2" in
		on)
			relay_on $1 1 $3
			;;
		off)
			relay_on $1 0 $3
			;;
		*)
			usage
			;;
	esac
fi
