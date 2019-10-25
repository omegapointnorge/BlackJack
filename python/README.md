### Setup
Start med å åpne en konsoll, og CD deg inn til mappen med denne filen.

#### Virtualenv
Alle python-prosjekter bør kjøre i sitt eget virtuelle miljø. Dette gjøres slik (eller tilsvarende, litt avhengig av hvordan python er installert):
```
python3 -m virtualenv -p python3 venv
```

og aktiveres slik:
```
[linux/mac]
source venv/bin/activate

[windows]
.\venv\Scripts\activate
``` 

#### Installasjon
BlackJack for python er laget som en python-pakke, og kan installeres som dette:
```
pip install -e .
```

Kontroller at installasjonen fungerte ved å kjøre testene:
```
python setup.py test
```

#### Kjør programmet
```
play
```
