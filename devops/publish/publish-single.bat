SET package_name=%1
SET package_version=2.1.0-rc2
SET target=../../../packages/Tests-All
cd ../build
call build-all
cd ../test
call test-all
cd ../pack
call pack-single %package_name%
cd ../../publish
call copy-single %package_name% %package_version% %target%
cd ../install
call uninstall-global-single.bat %package_name% %package_version%
cd ..