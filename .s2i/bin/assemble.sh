#!/bin/bash
echo "assembling"

/usr/libexec/s2i/assemble
rc=$?

if [ $rc -eq 0 ]; then
    echo "native assemble succeeded"
	yum install -y gcc-c++ make
	yum install nodejs
	cd /opt/app-root/WebApp
	npm install
	npm run build
else
    echo "failed assembling"
fi

exit $rc