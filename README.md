"# VR_DART_GAME" 

Le jeu de fléchette en VR  a été développé sur Unity 2022.3.57f1(LTS), Il est préférable de build l'application sur cette version d'UNITY afin d'éviter tout bug.

Une fois le projet récupérer ouvrir de projet avec Unity : 
- Projects -> ADD -> Add project from disk
- Puis lancer le projet cela peut prendre un peu de temp car Unity va retélécharger les bibliothèques

Mise en place de la VR, guide d'installation sur les casques PICO 4 entreprise:
- Télécharger le PICO Unity Integration SDK, dezipper l’archive (PICO Unity Integration SDK v3.1.0): https://developer.picoxr.com/resources/#sdk
- Dans la bare de menu de Unity aller dans Windows -> Package Manager
- Dans la nouvelle fenetre en haut à gauche cliquer sur le « + » et faite « Add package from disk... »
- Sélectionner le package.json se situant dans l’archive extraite que vous avez téléchargé
- Il est possible qu’il demande de restart Unity cliquer sur Oui, il ouvrira également une nouvelle fenêtre nommée « PXR SDK Setting » appuyer sur Apply.
- Dans la barre du menu Edit -> Project Settings --> XR Plug-in Management puis cliquer sur le logo Android puis cocher la case PICO (décocher les autres cases si elles sont cochées)
- Toujours dans le Project Settings aller dans XR Plug-in Management -> OpenXR puis cliquer sur le logo Android et ajouter un interaction profile en cliquant sur le « + » pour le PICO 4 c'est Khronos Simple Controller Profile
- Toujours dans le Project Settings aller dans « Player » puis « Other Settings », chercher la ligne « Minimum API Level », choisisser « Android 10.0 »
- Toujours dans le Project Settings aller dans « Player » puis « Other Settings », decocher la case Auto Graphics API puis sur le Graphics api qui apparait supprimer Vulkan en le selectionnant puis en cliquant sur le « - » pour garder OpenGLES3

Build une apk :
- Dans la barre de menu de Unity aller dans Build Settings...
- Si la scène n’est pas ajoutée dans la fenêtre « Scenes In Build » appuyer sur « Add Open Scenes » et ajouter la scène : Main VR Scene ( Assets -> Scenes -> Main VR Scène)
- Appuyer sur Build pour créer l’APK

Installer une apk :
- Brancher le casque à l’ordinateur
- Récupérer les fichiers adb qui ne fait pas partie du projet unity mais qui est dans le repos github: 
- Entrer la commande « ./adb.exe install nomApk.apk » dans un terminal de commande ( Le nom de l'apk est le nom choisit lors du build).
