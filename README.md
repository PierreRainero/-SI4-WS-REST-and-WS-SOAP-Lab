# SI4 : Service oriented computing - Web Services 
# Event extension

## Auteur
[Pierre RAINERO](pierre.rainero@hotmail.fr)

## Extensions
 - Graphical User Interface for the client 
 - Replace all the accesses to WS (beetween Velib WS and IWS, between IWS and WS Clients) with asynchronous ones.
 - Add a cache in IWS, to reduce communications between Velib WS and IWS.
 - Extend IWS with monitoring functionalities, i.e. various indicators that you can get and compute about the IWS activity. All this information will be accessible through a second WS attached to IWS. A specific client will be developed to access to this Monitor WS remotely. This specific client will display some of this monitor information graphically.  

## Programmation événementielle
Ce projet est une extension de la solution proposée sur "master". Il modifie légèrement l'architecture pour implémenter un système d'évènements (voir "Architecture du projet"). En effet, en plus des fonctionnalités déjà présentes il est possible pour un client de s'abonner à une station en précisant le temps maximum entre chaque rafraichissement. Si le nombre de vélos disponibles de cette station change, le client sera alors notifié et l'information sera affichée dans son terminal par le biais d'un callback.

## Architecture du projet   
 ![appels](doc/appels.jpg)    
     
     
**Pour plus de détails sur les autres fonctionnalités, se référer au README sur master.**
