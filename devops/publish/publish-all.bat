SET package_version=2.3.2
cd ../build
call build-all
cd ../test
call test-all
cd ../pack
call pack-all
cd ../publish
call copy-all %package_version%
cd ../install
call uninstall-global-all.bat %package_version%
cd ..
