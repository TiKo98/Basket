/***
* SCENE HINZUF�GEN & VIA BUTTON LADEN LASSEN
***/
1. Scenes-Ordner -> Rechtsklick -> Create -> Scene -> Name der Scene eingeben
2. Scene per Drag/Drop in Hierarchy ziehen
3. MainCamera und Directional Light aus neuer Scene l�schen
4. Menuleiste -> File -> Build Settings -> Add Open Scenes -> Dialog schlie�en (x) 
5. Hierarchy -> UI -> SceneSelectionMenu -> Scenes -> Content -> Existierenden Button kopieren und in Content hinzuf�gen
	-> umbennen in Btn<SceneName> -> in "Compound Button Text"-Komponente des Buttons beliebigen Namen eingeben
6. Hierarchy -> UI -> SceneSelectionMenu -> Scenes -> Content -> "ObjectCollection"-Komponente Button "Update Collection" klicken (der
	neu hinzugef�gt Button sollte dann richtig einger�ckt sein)
7. [Test] Play-Mode -> Button der Scene anklicken -> Scene sollte additive hinzugef�gt werden

/***
* SCENE BEARBEITEN
***/
1. (Wenn nicht schon getan) Scene in Hierarchy ziehen
2. GameObjects, Script, etc. hinzuf�gen
3. [Test] Scene aus Hierarchy entfernen (Hierarchy -> Rechtsklick auf Scene -> Remove Scene)

/***
* ANPASSEN WAS BEI WIEDERHOLTEM KLICK AUF LADE BUTTON GESCHEHEN SOLL
***/
1. SceneSelectionMenu -> SceneMenuReceiver-Komponente �ffnen (Doppelklick auf Script-Feld)
	-> Script �ffnet sich in Visual Studio -> HandleSceneSelection -> �hnlich wie f�r
	AdessoLogo Implementation hinzuf�gen