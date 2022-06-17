#Opis działania czytnika

Do czytnika zbliżamy kompatybilną karte w standardzie 13,56 Mhz. 

Krotkie zaświecenie żółtej diody oznacza poprawnie odczytanie karty. 

Krótkie zaświecenie zielonej diody oznacza rozpoczecie pracy.

Krotkie zaświecenie czerwonej diody oznacza zakończenie pracy.

Informacja o rozpoczeciu lub zakończeniu pracy pochodzi bezpośrednio z systemu działającego w chmurze. W związku z czym możliwe jest zainstalowanie więcej niż jednego czytnika na obiekcie. Pracownik, może rozpoczynać pracę korzystając z danego czytnika a kończyć ją korzystając z innego czytnika. Możliwe jest wykorzystywanie nieograniczonej ilości czytników.

#Informacje techniczne

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
