```
cd projekt
dotnet build
cd bin
dotnet publish -r linux-arm -o bin/arm
scp -r arm pi@172.25.1.130:/home/pi/projekt
```
Raspberyy PI
```
sudo nano /boot/config.txt
dtparam=spi=on
sudo reboot
cd projekt
dotnet projekt.dll
```