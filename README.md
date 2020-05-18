# OrderApplication

# TechnischeTest De Jaeger A.

=> App.Config file(s) kan je de connectionstring configureren en directory waar de gegenereerde bestanden plaats vinden.

Als eerst start je Ordergenerator na het configureren van de generator.cs file. 
Hier stel je oa. de delay tussen order creation in (standaard 5sec) en wanneer de applicatie moet stoppen (standaard 1 min)

- OrderConsumer waar bij de gegenereerde orders worden opgehaald en in de db worden geplaatst.

- OrderViewer waar je de orders kan filteren op datum, telkens bij ophaling word switchstatus getriggered.
