SET package_version=2.1.0-rc2
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
