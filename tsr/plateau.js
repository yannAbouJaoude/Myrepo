var canvas  = document.querySelector('#canvas');
var context = canvas.getContext('2d');

//initialisation du tableau des mots placés
var nb_motPlace = 0;
var motPlace = new Array();
for(var i=0; i<4; i++)
   motPlace[i] = new Array();
//0 : le mot
//1 : direction
//2 : X coordonnée de la 1ère lettre
//3 : Y ...


function console_output(string){
	document.form1.console_output.value=string + '\n' +document.form1.console_output.value;
}



function remplir_case(x, y, a, b){
	var case_esp=a;
	var taille_case=b;
	context.fillRect((x-1)*case_esp+1, (y-1)*case_esp+1, taille_case, taille_case);
}

var taille_case=35;
var case_esp=taille_case+2;
//var case_x = case_y = 1;

function plateau(){

	//var taille_case=35
	//var case_esp=taille_case+2//espacement entre les cases


	//toute les cases vertes
	context.fillStyle = "green";
	for (var i=0;i<16;i++){
		for (var j=0;j<16;j++){
			remplir_case(i, j, case_esp, taille_case);
		}
	}

	//toute les cases roses saumon   mot compte double
	context.fillStyle = "lightsalmon";
	//diagonale 1
	for (var i=0;i<16;i++){
		remplir_case(i, i, case_esp, taille_case);
	}
	//diagonale 2
	for (var i=0;i<16;i++){
		context.fillRect(i*case_esp+1, (14*case_esp+1)-(i*case_esp), taille_case, taille_case);		
	}

	//toute les cases bleu clair    lettre compte double
	context.fillStyle = "aqua"
	var tableau1x=[4,7,1,3,7,8,4];	
	var tableau1y=[1,3,4,7,7,4,8];
	for (i=0;i<7;i++){
		remplir_case(tableau1x[i], tableau1y[i], case_esp, taille_case);
		remplir_case(16-tableau1x[i], tableau1y[i], case_esp, taille_case);
		remplir_case(tableau1x[i], 16-tableau1y[i], case_esp, taille_case);
		remplir_case(16-tableau1x[i], 16-tableau1y[i], case_esp, taille_case);
	}

	//toute les cases bleu foncé    lettre compte triple
	context.fillStyle = "blue"
	var tableau1x=[6,6,2];	
	var tableau1y=[2,6,6];
	for (i=0;i<3;i++){
		remplir_case(tableau1x[i], tableau1y[i], case_esp, taille_case);
		remplir_case(16-tableau1x[i], tableau1y[i], case_esp, taille_case);
		remplir_case(tableau1x[i], 16-tableau1y[i], case_esp, taille_case);
		remplir_case(16-tableau1x[i], 16-tableau1y[i], case_esp, taille_case);
	}

	//toute les cases rouges      lettre compte triple
	context.fillStyle = "red"
	var tableau1x=[1,1,8];	
	var tableau1y=[1,8,1];
	for (i=0;i<3;i++){
		remplir_case(tableau1x[i], tableau1y[i], case_esp, taille_case);
		remplir_case(16-tableau1x[i], tableau1y[i], case_esp, taille_case);
		remplir_case(tableau1x[i], 16-tableau1y[i], case_esp, taille_case);
		remplir_case(16-tableau1x[i], 16-tableau1y[i], case_esp, taille_case);
	}


}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////     TABLEAU         /////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//Création du tableau bi-dimentionnel
var grille = new Array();
for(var i=0; i<17; i++)
   grille[i] = new Array();

// on parcourt les lignes...
for(var i=0; i<17; i++){
   // ... et dans chaque ligne, on parcourt les cellules
   for(var j=0; j<17; j++)
      {grille[i][j] = 0;}}

function afficher_tableau(){
	context.clearRect(0, 0, canvas.width, canvas.height);
	verifier_tableau();
	plateau();
	context.font = '15pt Arial';//taille et polices du texte
    context.fillStyle = 'black';//couleur du texte
	for(var i=0; i<16; i++){
      for(var j=0; j<16; j++){
      	if (grille[i][j]!=0){
      		//console_output("x : " + i + " // y : " + j + " // " + grille[i][j]);//affiche variables affectes du tableau
        context.fillText(grille[i][j],(i-1)*case_esp+taille_case*1/3,(j-1)*case_esp+taille_case*3/4 );
        }
      }
	}
	
}

function verifier_tableau(){//Corrige les mauvaises valeurs : mettre des 0 quand il n'y a pas de lettres
	for(var i=0; i<17; i++){
	 	for(var j=0; j<17; j++){
	 		if ((grille[i][j]!='0')&&(grille[i][j]!='A')&&(grille[i][j]!='B')&&(grille[i][j]!='C')&&(grille[i][j]!='D')&&(grille[i][j]!='E')&&(grille[i][j]!='F')&&(grille[i][j]!='G')&&(grille[i][j]!='H')&&(grille[i][j]!='I')&&(grille[i][j]!='J')&&(grille[i][j]!='K')&&(grille[i][j]!='L')&&(grille[i][j]!='M')&&(grille[i][j]!='N')&&(grille[i][j]!='O')&&(grille[i][j]!='P')&&(grille[i][j]!='Q')&&(grille[i][j]!='R')&&(grille[i][j]!='S')&&(grille[i][j]!='T')&&(grille[i][j]!='U')&&(grille[i][j]!='V')&&(grille[i][j]!='W')&&(grille[i][j]!='X')&&(grille[i][j]!='Y')&&(grille[i][j]!='Z')){
	 			console_output("[" + i +"][" + j + "]  : " + grille[i][j] + " => caractère non valide");
	 			grille[i][j] = 0;
	 		}
	 		

	 	}
	}
}


function affecter_lettre_tableau(){
	document.form1.afficher_lettre.value=document.form1.afficher_lettre.value.toUpperCase();//Met en MAJUSCULE !
	grille[case_x][case_y]=document.form1.afficher_lettre.value;
	//alert("1 : "+grille[case_x][case_y]);
	
	//context.fillText(grille[case_x][case_y],(case_x-1)*case_esp+taille_case/3,(case_y-1)*case_esp+taille_case*2/3 );
	//alert("2 : "+grille[case_x][case_y]);
	console_output("lettre placée : " + grille[case_x][case_y]);
	verifier_tableau();
	afficher_tableau();
}



function affecter_mot_tableau(mot1, direction1, x1, y1){
	document.form1.afficher_mot.value=document.form1.afficher_mot.value.toUpperCase();//met en majuscule
	var case_x1, case_y1;

	//détection validité
	var direction = document.form1.direction_mot.value;//la direction du mot
	var mot = document.form1.afficher_mot.value;

	//console_output(mot1 + '-' + direction1 + '-' + x1 + '-' + y1);
	if (mot1===undefined){
		//console_output("mode fct sans entrée");
		case_x1=case_x;
		case_y1=case_y;
	}
	else{
		direction=direction1;
		mot=mot1.toUpperCase();//le mot doit être en majuscule sinon les lettres seront pas acceptées
		case_x1=x1;
		case_y1=y1;
		//console_output("mode fct avec entrée");
	}

	
	var longueur_mot = mot.length;
	//console_output("Le mot : " + mot + " - Longueur du mot : " + longueur_mot);
	console_output("Vous voulez placer : " + mot);
	//console_output(case_x + "/" + case_y);
	var valide = true;
	

	if (((direction==2) && (longueur_mot>16-case_y1))||((direction==1) && (longueur_mot>16-case_x1))){//on vérifie qu'il y a assez de place
		console_output("On ne peut pas placer le mot");
		valide=false;
	}
	else {//vérifie que ça ne va pas remplacer une lettre déjà placée
		for (i=1; i<=longueur_mot; i++){
			if (direction==1){
				if ( (mot.charAt(i-1) != grille[case_x1+(i-1)][case_y1]) && (grille[case_x1+(i-1)][case_y1] != '0') ){
					valide=false;
				}
				//console_output("direction1 - " + mot.charAt(i-1) + ' : ' + grille[case_x1+(i-1)][case_y1]);
			}
			if (direction==2){
				if ( (mot.charAt(i-1) != grille[case_x1][case_y1+(i-1)]) && (grille[case_x1][case_y1+(i-1)] != '0') ){
					valide=false;
				}
				//console_output("direction2 - " + mot.charAt(i-1) + ' : ' + grille[case_x1][case_y1+(i-1)]);
			}
		}
	}
	

	//on attribue les lettres dans le tableau de lettre : grille
	if (valide == true){
		console_output("On peut placer le mot");

			//ici on remplis le tableau contenant les mots placés sur le tableau.
			motPlace[0][nb_motPlace]=mot;
			motPlace[1][nb_motPlace]=direction;
			motPlace[2][nb_motPlace]=case_x1;
			motPlace[3][nb_motPlace]=case_y1;

			nb_motPlace++;//on a placé un nouveau mot !!!
			premier_mot=false;//on a placé un mot



		for (i=1; i<=longueur_mot; i++){
			if (direction==1){
				grille[case_x1+(i-1)][case_y1]=mot.charAt(i-1);
			}
			if (direction==2){
				grille[case_x1][case_y1+(i-1)]=mot.charAt(i-1);
			}
		}
		afficher_tableau();
	}
	else{
		console_output("On ne peut pas placer le mot")
	}

}


//////////////////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////            DETECTION EVT SOURIS/CLAVIER            //////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////////////

function writeMessage(canvas, message) {
	var context = canvas.getContext('2d');
	
	context.font = '18pt Calibri';
	context.fillStyle = 'black';
	context.fillText(message, 10, 25);
}
function getMousePos(canvas, evt) {
	var rect = canvas.getBoundingClientRect();
	return {
		x: evt.clientX - rect.left,
		y: evt.clientY - rect.top
	};
}
/*var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d');*/
var case_x, case_y;

canvas.addEventListener('mousedown', function(evt) {
	var mousePos = getMousePos(canvas, evt);
	var message = 'Mouse position: ' + mousePos.x + ',' + mousePos.y;
	plateau();
	afficher_tableau();
	//writeMessage(canvas, message);
	//document.form1.console_output.value='Mouse position: ' + mousePos.x + ',' + mousePos.y;

	case_x=parseInt((mousePos.x-4)/case_esp)+1;
	case_y=parseInt((mousePos.y-4)/case_esp)+1;

	context.fillStyle = "rgba(0,0,0,0.5)";
	context.fillRect((case_x-1)*case_esp+1, (case_y-1)*case_esp+1, taille_case, taille_case);
	//console_output('Mouse position: ' + case_x + ',' + case_y +' / '+ mousePos.x + ',' + mousePos.y)
	console_output("Selection case  : " + "("+ case_x + ',' + case_y+")");
	//document.form1.console_output.value='Mouse position: ' + case_x + ',' + case_y +' / '+ mousePos.x + ',' + mousePos.y +'\n' + document.form1.console_output.value;
}, false);

canvas.addEventListener('mouseup', function(evt2) {
	context.clearRect(0, 0, canvas.width, canvas.height);
	plateau();
	afficher_tableau();
	document.form1.afficher_lettre.value='';
	document.form1.afficher_mot.value='';
	document.form1.afficher_mot.focus();//donne le focus
	//document.form1.console_output.value='Mouseup\n' + document.form1.console_output.value;
}, false);


//var abc=1;
canvas.addEventListener('mousemove', function(evt3) {
	var mousePos = getMousePos(canvas, evt3);
	//var message = 'Mouse position: ' + mousePos.x + ',' + mousePos.y;
		
	//console_output('Mouse position: ' + mousePos.x + ',' + mousePos.y);

	var case_x3=parseInt((mousePos.x-4)/case_esp)+1;
	var case_y3=parseInt((mousePos.y-4)/case_esp)+1;

	context.clearRect(0, 0, canvas.width, canvas.height);
	plateau();
	afficher_tableau();
	//writeMessage(canvas, message);
	//console_output("mousemove !");
	
	context.fillStyle = "rgba(0,0,0,0.1)";
	context.fillRect((case_x3-1)*case_esp+1, (case_y3-1)*case_esp+1, taille_case, taille_case);
	//console_output('Mousemove :' + abc);
	//abc++;
}, false);

document.addEventListener('keydown', function(evt4) {
    if( (evt4.keyCode == '1'.charCodeAt()) || (evt4.keyCode == '97') ){
    	evt4.preventDefault();
    	document.form1.direction_mot.value='1';
    }
    if( (evt4.keyCode == '2'.charCodeAt()) || (evt4.keyCode == '98') ){
    	evt4.preventDefault();
    	document.form1.direction_mot.value='2';
    }
    if( (evt4.keyCode == '7'.charCodeAt()) || (evt4.keyCode == '103') ){
    	evt4.preventDefault();
    	document.form1.input.focus();
    }
    if( (evt4.keyCode == '9'.charCodeAt()) || (evt4.keyCode == '105')  ){
    	evt4.preventDefault();
    	document.form1.afficher_mot.focus();
    }
    if( (evt4.keyCode == '5'.charCodeAt()) || (evt4.keyCode == '101')  ){
    	evt4.preventDefault();
    	document.form1.afficher_lettre.value='';
		document.form1.afficher_mot.value='';
		document.form1.input.value='';
    }
    if( (evt4.ctrlKey) && (evt4.keyCode == '8') ){
    	evt4.preventDefault();
    	for(var i=0; i<17; i++){
   			for(var j=0; j<17; j++){
   				grille[i][j] = 0;
   			}
   		}
   		
		for(var i=0; i<4; i++){
			for(var j=0; j<=nb_motPlace;j++){
		   		motPlace[i][j]=0;
			}
		}
		nb_motPlace = 0;
	    context.clearRect(0, 0, canvas.width, canvas.height);
		plateau();
		afficher_tableau();
    }
    //console_output("Appui : " + String.fromCharCode(evt4.keyCode) + "/" + evt4.keyCode)

}, false);






////////////////////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////       PARTIE RESOLVEUR  //////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////////////////




//var monTableau = [""];


//console_output("montabl1");
var posy;	//position de la lettre deja placé
var posx;
var place;
var directionResolveur //1=hozirontal; 2= vertical
var nbMaxDeCaractèreAGauche;
var nbMaxDeCaractèreADroite;
var nbMaxDeCaractèreEnHaut;
var nbMaxDeCaractèreEnBas;
//grille[igrille][jgrille] est un tableau a double entrée contenant les lettres posé en fonction de leur position
// grille[0][0] est la case en haut a gauche. grille[14][14] est la case en bas a droite
var saisie1;

var maxPoint = 0;

var nb_resultat = 0;
var resultats = new Array();//le tableau des résultats
for(var i=0; i<5000; i++){
	resultats[i] = new Array();
}

var resultats_tries = new Array();//le tableau des résultats triés
for(var i=0; i<5000; i++){
	resultats_tries[i] = new Array();
}

var premier_mot = true;



function start(form1) {
	maxPoint = 0;
	nb_resultat = 0;
	saisie1=document.form1.input.value;


	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////                        Le premier mot à placer                         ////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


for(var i=0; i<5000; i++){
	resultats[i] = new Array();
}

	if (premier_mot==true){
		posx=8;
		posy=8;
		directionResolveur = 1;
		trouveLesMots();
}









	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////        On fait un mot à partir d'1 lettre du plateau déjà placée       ////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	for(var igrille=1; igrille<16; igrille++){
		for(var jgrille=1; jgrille<16; jgrille++){



			if(grille[igrille][jgrille]!=0){				//0 doit etre associé a la valeur d'une case vide

				var pdroite=-1;
				var pgauche=-1;
				var igrilleH=igrille;

				while((grille[(igrilleH+1)][jgrille]==0) && (igrilleH!=15)){
					pdroite=pdroite+1;
					if(igrilleH==14){pdroite=pdroite+1;}
					igrilleH=igrilleH+1;
				}

				igrilleH=igrille;


				if (igrilleH==1){//si la lettre est sur le bord gauche , pour que ça fonctionne
					pgauche=0;
				}

				while((grille[igrilleH-1][jgrille]==0) && (igrilleH!=1)){
				

					pgauche=pgauche+1;
					if(igrilleH==2){pgauche=pgauche+1;}
					igrilleH=igrilleH-1;
				}

				if((pdroite!=-1) && (pgauche!=-1)){
					place=pdroite+pgauche+1;
					if(place>0){
						posx=igrille;
						posy=jgrille;
						directionResolveur = 1;	//1 correspond à "résultat à placer horizontalement"
						nbMaxDeCaractèreAGauche=igrille-igrilleH;
						nbMaxDeCaractèreADroite=place-nbMaxDeCaractèreAGauche-1;
						if(grille[igrille-1][jgrille-1]!=0||grille[igrille-1][jgrille+1]!=0){
							nbMaxDeCaractèreAGauche=0;
						}
						if(grille[igrille+1][jgrille-1]!=0||grille[igrille+1][jgrille+1]!=0){
							nbMaxDeCaractèreADroit=0;
						}
						//console_output("G:" + nbMaxDeCaractèreAGauche + " / D:" + nbMaxDeCaractèreADroite + " / Dir:" + directionResolveur + " / Pos: x:" + posx + " y:" + posy);
						trouveLesMots();
					}
				}
					
					//Ici commence la recherche verticale

				var pbas=-1;
				var phaut=-1;
				var jgrilleV=jgrille;

				while((grille[igrille][(jgrilleV+1)]==0) && (jgrilleV!=15)){
					pbas=pbas+1;
					if(jgrilleV==14){pbas=pbas+1;}
					jgrilleV=jgrilleV+1;
				}

				jgrilleV=jgrille;


				if (jgrilleV==1){//si la lettre est sur le bord haut , pour que ça fonctionne
					phaut=0;
				}

				while((grille[igrille][jgrilleV-1]==0) && (jgrilleV!=1)){
				

					phaut=phaut+1;
					if(jgrilleV==2){phaut=phaut+1;}
					jgrilleV=jgrilleV-1;
				}

				if((pbas!=-1) && (phaut!=-1)){
					place=pbas+phaut+1;
					if(place>0){
						posx=igrille;
						posy=jgrille;
						directionResolveur = 2;	//2 correspond a vertical
						nbMaxDeCaractèreEnHaut=jgrille-jgrilleV;
						nbMaxDeCaractèreEnBas=place-nbMaxDeCaractèreEnHaut-1;

						if(grille[igrille-1][jgrille-1]!=0||grille[igrille+1][jgrille-1]!=0){
							nbMaxDeCaractèreEnHaut=0;
						}
						if(grille[igrille-1][jgrille+1]!=0||grille[igrille+1][jgrille+1]!=0){
							nbMaxDeCaractèreEnBas=0;
						}

						//console_output("H:" + nbMaxDeCaractèreEnHaut + " / B:" + nbMaxDeCaractèreEnBas + " / Dir:" + directionResolveur + " / Pos: x:" + posx + " y:" + posy);
						trouveLesMots();
					}
				}
			}
		}
	}

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	////////////////////////          On fait un nouveau mot à partir d'1 mot déjà placé           /////////////////////////
	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


	var xtest;
	var ytest;


	for(var i=0; i<nb_motPlace; i++){
		//console_output("i1:" + i)
		for (var position=0;position<336529;position++){
			var motTeste = monTableau[position].toLowerCase();
			motTeste = motTeste.replace(/[èéêë]/g,"e");
			motTeste = motTeste.replace(/[àâä]/g,"a");
			motTeste = motTeste.replace(/[ùûü]/g,"u");
			motTeste = motTeste.replace(/[îï]/g,"i");
			motTeste = motTeste.replace(/[ôö]/g,"o");
			motTeste = motTeste.replace(/[ç]/g,"c");
			
			motPlace[0][i]=motPlace[0][i].toLowerCase();

			if(motTeste.indexOf(motPlace[0][i])!=-1){
				
				var direction = motPlace[1][i];
				var mot = motPlace[0][i];


				if(motPlace[1][i]==1){		//horizontal
					xtest=motPlace[2][i]-motTeste.indexOf(mot);
					ytest=motPlace[3][i];

				}

				if(motPlace[1][i]==2){		//vertical
					xtest=motPlace[2][i];
					ytest=motPlace[3][i]-motTeste.indexOf(mot);
					
				}


				

				var longueur_mot = motTeste.length;
				var valide = true;
				if((ytest<1) || (xtest<1) ){
					valide = false;
					//console_output("mot non valide1 :" + motTeste);
				}
				if(motTeste==mot){
					valide=false;
				}
				
				if (((direction==2) && (longueur_mot>16-ytest))||((direction==1) && (longueur_mot>16-xtest))){//on vérifie qu'il y a assez de place
					valide = false;
					//console_output("mot non valide2 :" + motTeste);
					//console_output("On ne peut pas placer le mot");
				}
				else {//vérifie que ça ne va pas remplacer une lettre déjà placée
					if( valide == true ){
						for (var j=1; j<=longueur_mot; j++){
							if (direction==1){
								if ( (motTeste.charAt(j-1).toUpperCase() != grille[xtest+(j-1)][ytest]) && (grille[xtest+(j-1)][ytest] != '0') ){
									valide=false;
									//console_output("mot non valide3 :" + motTeste);
									//console_output( motTeste.charAt(j-1).toUpperCase() + " : " + grille[xtest+(j-1)][ytest]);
								}
							}
							if (direction==2){
								if ( (motTeste.charAt(j-1).toUpperCase() != grille[xtest][ytest+(j-1)]) && (grille[xtest][ytest+(j-1)] != '0') ){
									valide=false;
									//console_output("mot non valide4 :" + motTeste);
								}
							}
						}
					}
				}

				if(valide==true){	
					var lettresEnPlus = motTeste.replace(mot,"");

					saisie=saisie1.toLowerCase();
					//console_output("Vous avez saisi : " + saisie + " / 1:" + motTeste);


					var ia = saisie.indexOf("a");var nbA1 = 0 ;while (ia != -1){nbA1=nbA1+1;ia = saisie.indexOf("a", ia+1);}
					var ib = saisie.indexOf("b");var nbB1 = 0 ;while (ib != -1){nbB1=nbB1+1;ib = saisie.indexOf("b", ib+1);}
					var ic = saisie.indexOf("c");var nbC1 = 0 ;while (ic != -1){nbC1=nbC1+1;ic = saisie.indexOf("c", ic+1);}
					var id = saisie.indexOf("d");var nbD1 = 0 ;while (id != -1){nbD1=nbD1+1;id = saisie.indexOf("d", id+1);}
					var ie = saisie.indexOf("e");var nbE1 = 0 ;while (ie != -1){nbE1=nbE1+1;ie = saisie.indexOf("e", ie+1);}
					var iff= saisie.indexOf("f");var nbF1 = 0 ;while (iff!= -1){nbF1=nbF1+1;iff= saisie.indexOf("f", iff+1);}
					var ig = saisie.indexOf("g");var nbG1 = 0 ;while (ig != -1){nbG1=nbG1+1;ig = saisie.indexOf("g", ig+1);}
					var ih = saisie.indexOf("h");var nbH1 = 0 ;while (ih != -1){nbH1=nbH1+1;ih = saisie.indexOf("h", ih+1);}
					var ii = saisie.indexOf("i");var nbI1 = 0 ;while (ii != -1){nbI1=nbI1+1;ii = saisie.indexOf("i", ii+1);}
					var ij = saisie.indexOf("j");var nbJ1 = 0 ;while (ij != -1){nbJ1=nbJ1+1;ij = saisie.indexOf("j", ij+1);}
					var ik = saisie.indexOf("k");var nbK1 = 0 ;while (ik != -1){nbK1=nbK1+1;ik = saisie.indexOf("k", ik+1);}
					var il = saisie.indexOf("l");var nbL1 = 0 ;while (il != -1){nbL1=nbL1+1;il = saisie.indexOf("l", il+1);}
					var im = saisie.indexOf("m");var nbM1 = 0 ;while (im != -1){nbM1=nbM1+1;im = saisie.indexOf("m", im+1);}
					var inn= saisie.indexOf("n");var nbN1 = 0 ;while (inn!= -1){nbN1=nbN1+1;inn= saisie.indexOf("n", inn+1);}
					var io = saisie.indexOf("o");var nbO1 = 0 ;while (io != -1){nbO1=nbO1+1;io = saisie.indexOf("o", io+1);}
					var ip = saisie.indexOf("p");var nbP1 = 0 ;while (ip != -1){nbP1=nbP1+1;ip = saisie.indexOf("p", ip+1);}
					var iq = saisie.indexOf("q");var nbQ1 = 0 ;while (iq != -1){nbQ1=nbQ1+1;iq = saisie.indexOf("q", iq+1);}
					var ir = saisie.indexOf("r");var nbR1 = 0 ;while (ir != -1){nbR1=nbR1+1;ir = saisie.indexOf("r", ir+1);}
					var is = saisie.indexOf("s");var nbS1 = 0 ;while (is != -1){nbS1=nbS1+1;is = saisie.indexOf("s", is+1);}
					var it = saisie.indexOf("t");var nbT1 = 0 ;while (it != -1){nbT1=nbT1+1;it = saisie.indexOf("t", it+1);}
					var iu = saisie.indexOf("u");var nbU1 = 0 ;while (iu != -1){nbU1=nbU1+1;iu = saisie.indexOf("u", iu+1);}
					var iv = saisie.indexOf("v");var nbV1 = 0 ;while (iv != -1){nbV1=nbV1+1;iv = saisie.indexOf("v", iv+1);}
					var iw = saisie.indexOf("w");var nbW1 = 0 ;while (iw != -1){nbW1=nbW1+1;iw = saisie.indexOf("w", iw+1);}
					var ix = saisie.indexOf("x");var nbX1 = 0 ;while (ix != -1){nbX1=nbX1+1;ix = saisie.indexOf("x", ix+1);}
					var iy = saisie.indexOf("y");var nbY1 = 0 ;while (iy != -1){nbY1=nbY1+1;iy = saisie.indexOf("y", iy+1);}
					var iz = saisie.indexOf("z");var nbZ1 = 0 ;while (iz != -1){nbZ1=nbZ1+1;iz = saisie.indexOf("z", iz+1);}



					var ia = lettresEnPlus.indexOf("a");var nbA = 0 ;while (ia != -1){nbA=nbA+1;ia = lettresEnPlus.indexOf("a", ia+1);}
					var ib = lettresEnPlus.indexOf("b");var nbB = 0 ;while (ib != -1){nbB=nbB+1;ib = lettresEnPlus.indexOf("b", ib+1);}
					var ic = lettresEnPlus.indexOf("c");var nbC = 0 ;while (ic != -1){nbC=nbC+1;ic = lettresEnPlus.indexOf("c", ic+1);}
					var id = lettresEnPlus.indexOf("d");var nbD = 0 ;while (id != -1){nbD=nbD+1;id = lettresEnPlus.indexOf("d", id+1);}
					var ie = lettresEnPlus.indexOf("e");var nbE = 0 ;while (ie != -1){nbE=nbE+1;ie = lettresEnPlus.indexOf("e", ie+1);}
					var iff= lettresEnPlus.indexOf("f");var nbF = 0 ;while (iff!= -1){nbF=nbF+1;iff= lettresEnPlus.indexOf("f", iff+1);}
					var ig = lettresEnPlus.indexOf("g");var nbG = 0 ;while (ig != -1){nbG=nbG+1;ig = lettresEnPlus.indexOf("g", ig+1);}
					var ih = lettresEnPlus.indexOf("h");var nbH = 0 ;while (ih != -1){nbH=nbH+1;ih = lettresEnPlus.indexOf("h", ih+1);}
					var ii = lettresEnPlus.indexOf("i");var nbI = 0 ;while (ii != -1){nbI=nbI+1;ii = lettresEnPlus.indexOf("i", ii+1);}
					var ij = lettresEnPlus.indexOf("j");var nbJ = 0 ;while (ij != -1){nbJ=nbJ+1;ij = lettresEnPlus.indexOf("j", ij+1);}
					var ik = lettresEnPlus.indexOf("k");var nbK = 0 ;while (ik != -1){nbK=nbK+1;ik = lettresEnPlus.indexOf("k", ik+1);}
					var il = lettresEnPlus.indexOf("l");var nbL = 0 ;while (il != -1){nbL=nbL+1;il = lettresEnPlus.indexOf("l", il+1);}
					var im = lettresEnPlus.indexOf("m");var nbM = 0 ;while (im != -1){nbM=nbM+1;im = lettresEnPlus.indexOf("m", im+1);}
					var inn= lettresEnPlus.indexOf("n");var nbN = 0 ;while (inn!= -1){nbN=nbN+1;inn= lettresEnPlus.indexOf("n", inn+1);}
					var io = lettresEnPlus.indexOf("o");var nbO = 0 ;while (io != -1){nbO=nbO+1;io = lettresEnPlus.indexOf("o", io+1);}
					var ip = lettresEnPlus.indexOf("p");var nbP = 0 ;while (ip != -1){nbP=nbP+1;ip = lettresEnPlus.indexOf("p", ip+1);}
					var iq = lettresEnPlus.indexOf("q");var nbQ = 0 ;while (iq != -1){nbQ=nbQ+1;iq = lettresEnPlus.indexOf("q", iq+1);}
					var ir = lettresEnPlus.indexOf("r");var nbR = 0 ;while (ir != -1){nbR=nbR+1;ir = lettresEnPlus.indexOf("r", ir+1);}
					var is = lettresEnPlus.indexOf("s");var nbS = 0 ;while (is != -1){nbS=nbS+1;is = lettresEnPlus.indexOf("s", is+1);}
					var it = lettresEnPlus.indexOf("t");var nbT = 0 ;while (it != -1){nbT=nbT+1;it = lettresEnPlus.indexOf("t", it+1);}
					var iu = lettresEnPlus.indexOf("u");var nbU = 0 ;while (iu != -1){nbU=nbU+1;iu = lettresEnPlus.indexOf("u", iu+1);}
					var iv = lettresEnPlus.indexOf("v");var nbV = 0 ;while (iv != -1){nbV=nbV+1;iv = lettresEnPlus.indexOf("v", iv+1);}
					var iw = lettresEnPlus.indexOf("w");var nbW = 0 ;while (iw != -1){nbW=nbW+1;iw = lettresEnPlus.indexOf("w", iw+1);}
					var ix = lettresEnPlus.indexOf("x");var nbX = 0 ;while (ix != -1){nbX=nbX+1;ix = lettresEnPlus.indexOf("x", ix+1);}
					var iy = lettresEnPlus.indexOf("y");var nbY = 0 ;while (iy != -1){nbY=nbY+1;iy = lettresEnPlus.indexOf("y", iy+1);}
					var iz = lettresEnPlus.indexOf("z");var nbZ = 0 ;while (iz != -1){nbZ=nbZ+1;iz = lettresEnPlus.indexOf("z", iz+1);}


					if((nbA1>=nbA) && (nbB1>=nbB) && (nbC1>=nbC) && (nbD1>=nbD) && (nbE1>=nbE) && (nbF1>=nbF) && (nbG1>=nbG) && (nbH1>=nbH) && (nbI1>=nbI) && (nbJ1>=nbJ) && (nbK1>=nbK) && (nbL1>=nbL) && (nbM1>=nbM) && (nbN1>=nbN) && (nbO1>=nbO) && (nbP1>=nbP) && (nbQ1>=nbQ) && (nbR1>=nbR) && (nbS1>=nbS) && (nbT1>=nbT) && (nbU1>=nbU) && (nbV1>=nbV) && (nbW1>=nbW) && (nbX1>=nbX) && (nbY1>=nbY) && (nbZ1>=nbZ)){

						//console_output(motTeste);

						traitement_des_resultats(motTeste,direction,xtest,ytest)


					}
				}
			}
		}
	}


	/* var num_resultat=1;
	   var num_resultat2=1;  */

	console_output("   ***   Fin des résultats   ***   ");
	for (var i=1; i<=maxPoint;i++){
		for (var j=0;j<=nb_resultat;j++){
			if (resultats[j][4]==i){
				
				if(resultats[j][0].length>7){console_output(resultats[j][0] + "	Dir: " + resultats[j][1] + " 	x: " + resultats[j][2] + " y: " + resultats[j][3]  + " 	p: " + resultats[j][4]);}
				if(resultats[j][0].length<=7){console_output(resultats[j][0] + "		Dir: " + resultats[j][1] + " 	x: " + resultats[j][2] + " y: " + resultats[j][3]  + " 	p: " + resultats[j][4]);}

				/*
				if (num_resultat >nb_resultat-4){
					document.form1.best_resultats.options[num_resultat2-1].text=resultats[j][0];
					num_resultat2++;
				}
				num_resultat++;*/

				

			}
		}
	}
	console_output("   ***   Début des résultats   ***   ");
	var a=1;
	for (var i=maxPoint; i>1;i--){             //on trie les résultats dans l'ordre décroissant
		for (var j=0;j<=nb_resultat;j++){
			if (resultats[j][4]==i){
				resultats_tries[a][0]=resultats[j][0];
				resultats_tries[a][1]=resultats[j][1];
				resultats_tries[a][2]=resultats[j][2];
				resultats_tries[a][3]=resultats[j][3];
				resultats_tries[a][4]=resultats[j][4];
				a++;
			}
		}
	}

	for (var i=0;i<4;i++){
		document.form1.best_resultats.options[i].text=resultats_tries[i+1][0];

	}
}







function trouveLesMots() {


	saisie=saisie1+grille[posx][posy];
	
	saisie=saisie.toLowerCase();
	//console_output("Vous avez saisi : " + saisie + " / 1:" + saisie1);


	var ia = saisie.indexOf("a");var nbA1 = 0 ;while (ia != -1){nbA1=nbA1+1;ia = saisie.indexOf("a", ia+1);}
	var ib = saisie.indexOf("b");var nbB1 = 0 ;while (ib != -1){nbB1=nbB1+1;ib = saisie.indexOf("b", ib+1);}
	var ic = saisie.indexOf("c");var nbC1 = 0 ;while (ic != -1){nbC1=nbC1+1;ic = saisie.indexOf("c", ic+1);}
	var id = saisie.indexOf("d");var nbD1 = 0 ;while (id != -1){nbD1=nbD1+1;id = saisie.indexOf("d", id+1);}
	var ie = saisie.indexOf("e");var nbE1 = 0 ;while (ie != -1){nbE1=nbE1+1;ie = saisie.indexOf("e", ie+1);}
	var iff= saisie.indexOf("f");var nbF1 = 0 ;while (iff!= -1){nbF1=nbF1+1;iff= saisie.indexOf("f", iff+1);}
	var ig = saisie.indexOf("g");var nbG1 = 0 ;while (ig != -1){nbG1=nbG1+1;ig = saisie.indexOf("g", ig+1);}
	var ih = saisie.indexOf("h");var nbH1 = 0 ;while (ih != -1){nbH1=nbH1+1;ih = saisie.indexOf("h", ih+1);}
	var ii = saisie.indexOf("i");var nbI1 = 0 ;while (ii != -1){nbI1=nbI1+1;ii = saisie.indexOf("i", ii+1);}
	var ij = saisie.indexOf("j");var nbJ1 = 0 ;while (ij != -1){nbJ1=nbJ1+1;ij = saisie.indexOf("j", ij+1);}
	var ik = saisie.indexOf("k");var nbK1 = 0 ;while (ik != -1){nbK1=nbK1+1;ik = saisie.indexOf("k", ik+1);}
	var il = saisie.indexOf("l");var nbL1 = 0 ;while (il != -1){nbL1=nbL1+1;il = saisie.indexOf("l", il+1);}
	var im = saisie.indexOf("m");var nbM1 = 0 ;while (im != -1){nbM1=nbM1+1;im = saisie.indexOf("m", im+1);}
	var inn= saisie.indexOf("n");var nbN1 = 0 ;while (inn!= -1){nbN1=nbN1+1;inn= saisie.indexOf("n", inn+1);}
	var io = saisie.indexOf("o");var nbO1 = 0 ;while (io != -1){nbO1=nbO1+1;io = saisie.indexOf("o", io+1);}
	var ip = saisie.indexOf("p");var nbP1 = 0 ;while (ip != -1){nbP1=nbP1+1;ip = saisie.indexOf("p", ip+1);}
	var iq = saisie.indexOf("q");var nbQ1 = 0 ;while (iq != -1){nbQ1=nbQ1+1;iq = saisie.indexOf("q", iq+1);}
	var ir = saisie.indexOf("r");var nbR1 = 0 ;while (ir != -1){nbR1=nbR1+1;ir = saisie.indexOf("r", ir+1);}
	var is = saisie.indexOf("s");var nbS1 = 0 ;while (is != -1){nbS1=nbS1+1;is = saisie.indexOf("s", is+1);}
	var it = saisie.indexOf("t");var nbT1 = 0 ;while (it != -1){nbT1=nbT1+1;it = saisie.indexOf("t", it+1);}
	var iu = saisie.indexOf("u");var nbU1 = 0 ;while (iu != -1){nbU1=nbU1+1;iu = saisie.indexOf("u", iu+1);}
	var iv = saisie.indexOf("v");var nbV1 = 0 ;while (iv != -1){nbV1=nbV1+1;iv = saisie.indexOf("v", iv+1);}
	var iw = saisie.indexOf("w");var nbW1 = 0 ;while (iw != -1){nbW1=nbW1+1;iw = saisie.indexOf("w", iw+1);}
	var ix = saisie.indexOf("x");var nbX1 = 0 ;while (ix != -1){nbX1=nbX1+1;ix = saisie.indexOf("x", ix+1);}
	var iy = saisie.indexOf("y");var nbY1 = 0 ;while (iy != -1){nbY1=nbY1+1;iy = saisie.indexOf("y", iy+1);}
	var iz = saisie.indexOf("z");var nbZ1 = 0 ;while (iz != -1){nbZ1=nbZ1+1;iz = saisie.indexOf("z", iz+1);}




	for (var position=0;position<336529;position++){
		

		//on s'occupe des mots avec accents et en majuscule
		var motTeste = monTableau[position].toLowerCase();
		motTeste = motTeste.replace(/[èéêë]/g,"e");
		motTeste = motTeste.replace(/[àâä]/g,"a");
		motTeste = motTeste.replace(/[ùûü]/g,"u");
		motTeste = motTeste.replace(/[îï]/g,"i");
		motTeste = motTeste.replace(/[ôö]/g,"o");
		motTeste = motTeste.replace(/[ç]/g,"c");


		//console_output("monTableau[position] : " + monTableau[position]);

		var ia = motTeste.indexOf("a");var nbA = 0 ;while (ia != -1){nbA=nbA+1;ia = motTeste.indexOf("a", ia+1);}
		var ib = motTeste.indexOf("b");var nbB = 0 ;while (ib != -1){nbB=nbB+1;ib = motTeste.indexOf("b", ib+1);}
		var ic = motTeste.indexOf("c");var nbC = 0 ;while (ic != -1){nbC=nbC+1;ic = motTeste.indexOf("c", ic+1);}
		var id = motTeste.indexOf("d");var nbD = 0 ;while (id != -1){nbD=nbD+1;id = motTeste.indexOf("d", id+1);}
		var ie = motTeste.indexOf("e");var nbE = 0 ;while (ie != -1){nbE=nbE+1;ie = motTeste.indexOf("e", ie+1);}
		var iff= motTeste.indexOf("f");var nbF = 0 ;while (iff!= -1){nbF=nbF+1;iff= motTeste.indexOf("f", iff+1);}
		var ig = motTeste.indexOf("g");var nbG = 0 ;while (ig != -1){nbG=nbG+1;ig = motTeste.indexOf("g", ig+1);}
		var ih = motTeste.indexOf("h");var nbH = 0 ;while (ih != -1){nbH=nbH+1;ih = motTeste.indexOf("h", ih+1);}
		var ii = motTeste.indexOf("i");var nbI = 0 ;while (ii != -1){nbI=nbI+1;ii = motTeste.indexOf("i", ii+1);}
		var ij = motTeste.indexOf("j");var nbJ = 0 ;while (ij != -1){nbJ=nbJ+1;ij = motTeste.indexOf("j", ij+1);}
		var ik = motTeste.indexOf("k");var nbK = 0 ;while (ik != -1){nbK=nbK+1;ik = motTeste.indexOf("k", ik+1);}
		var il = motTeste.indexOf("l");var nbL = 0 ;while (il != -1){nbL=nbL+1;il = motTeste.indexOf("l", il+1);}
		var im = motTeste.indexOf("m");var nbM = 0 ;while (im != -1){nbM=nbM+1;im = motTeste.indexOf("m", im+1);}
		var inn= motTeste.indexOf("n");var nbN = 0 ;while (inn!= -1){nbN=nbN+1;inn= motTeste.indexOf("n", inn+1);}
		var io = motTeste.indexOf("o");var nbO = 0 ;while (io != -1){nbO=nbO+1;io = motTeste.indexOf("o", io+1);}
		var ip = motTeste.indexOf("p");var nbP = 0 ;while (ip != -1){nbP=nbP+1;ip = motTeste.indexOf("p", ip+1);}
		var iq = motTeste.indexOf("q");var nbQ = 0 ;while (iq != -1){nbQ=nbQ+1;iq = motTeste.indexOf("q", iq+1);}
		var ir = motTeste.indexOf("r");var nbR = 0 ;while (ir != -1){nbR=nbR+1;ir = motTeste.indexOf("r", ir+1);}
		var is = motTeste.indexOf("s");var nbS = 0 ;while (is != -1){nbS=nbS+1;is = motTeste.indexOf("s", is+1);}
		var it = motTeste.indexOf("t");var nbT = 0 ;while (it != -1){nbT=nbT+1;it = motTeste.indexOf("t", it+1);}
		var iu = motTeste.indexOf("u");var nbU = 0 ;while (iu != -1){nbU=nbU+1;iu = motTeste.indexOf("u", iu+1);}
		var iv = motTeste.indexOf("v");var nbV = 0 ;while (iv != -1){nbV=nbV+1;iv = motTeste.indexOf("v", iv+1);}
		var iw = motTeste.indexOf("w");var nbW = 0 ;while (iw != -1){nbW=nbW+1;iw = motTeste.indexOf("w", iw+1);}
		var ix = motTeste.indexOf("x");var nbX = 0 ;while (ix != -1){nbX=nbX+1;ix = motTeste.indexOf("x", ix+1);}
		var iy = motTeste.indexOf("y");var nbY = 0 ;while (iy != -1){nbY=nbY+1;iy = motTeste.indexOf("y", iy+1);}
		var iz = motTeste.indexOf("z");var nbZ = 0 ;while (iz != -1){nbZ=nbZ+1;iz = motTeste.indexOf("z", iz+1);}
		//console_output("lol");



		if (premier_mot==false){

			if((nbA1>=nbA) && (nbB1>=nbB) && (nbC1>=nbC) && (nbD1>=nbD) && (nbE1>=nbE) && (nbF1>=nbF) && (nbG1>=nbG) && (nbH1>=nbH) && (nbI1>=nbI) && (nbJ1>=nbJ) && (nbK1>=nbK) && (nbL1>=nbL) && (nbM1>=nbM) && (nbN1>=nbN) && (nbO1>=nbO) && (nbP1>=nbP) && (nbQ1>=nbQ) && (nbR1>=nbR) && (nbS1>=nbS) && (nbT1>=nbT) && (nbU1>=nbU) && (nbV1>=nbV) && (nbW1>=nbW) && (nbX1>=nbX) && (nbY1>=nbY) && (nbZ1>=nbZ)){
				position_de_la_lettre_dans_le_mot=motTeste.indexOf(grille[posx][posy].toLowerCase()) + 1;

				if( (directionResolveur==1) && (nbMaxDeCaractèreAGauche >= position_de_la_lettre_dans_le_mot-1) && (nbMaxDeCaractèreADroite >= motTeste.length - position_de_la_lettre_dans_le_mot) && (motTeste.indexOf(grille[posx][posy].toLowerCase())!=-1) ){

					//console_output(monTableau[position]);
					if(motTeste.length>=2){			//pour empeché la sorte de mot ne contenant QUE la lettre deja placé
						traitement_des_resultats(motTeste,directionResolveur, posx-position_de_la_lettre_dans_le_mot+1 ,posy);
					}


				}
				
				if( (directionResolveur==2) && (nbMaxDeCaractèreEnHaut >= position_de_la_lettre_dans_le_mot-1) && (nbMaxDeCaractèreEnBas >= motTeste.length - position_de_la_lettre_dans_le_mot) && (motTeste.indexOf(grille[posx][posy].toLowerCase())!=-1) ){

					//console_output(monTableau[position]);
					if(motTeste.length>=2){		//pour empeché la sorte de mot ne contenant QUE la lettre deja placé
					traitement_des_resultats(motTeste,directionResolveur, posx, posy-position_de_la_lettre_dans_le_mot+1)
					}
				}
			}
		}
		else{
			if((nbA1>=nbA) && (nbB1>=nbB) && (nbC1>=nbC) && (nbD1>=nbD) && (nbE1>=nbE) && (nbF1>=nbF) && (nbG1>=nbG) && (nbH1>=nbH) && (nbI1>=nbI) && (nbJ1>=nbJ) && (nbK1>=nbK) && (nbL1>=nbL) && (nbM1>=nbM) && (nbN1>=nbN) && (nbO1>=nbO) && (nbP1>=nbP) && (nbQ1>=nbQ) && (nbR1>=nbR) && (nbS1>=nbS) && (nbT1>=nbT) && (nbU1>=nbU) && (nbV1>=nbV) && (nbW1>=nbW) && (nbX1>=nbX) && (nbY1>=nbY) && (nbZ1>=nbZ)){

				for (var i=0; i<=motTeste.length; i++){
					if(motTeste.length+posx-i>8 && posx-i<8){
						traitement_des_resultats(motTeste,directionResolveur, posx-i ,posy);
					}

				}







			}



		}



	}


	
}


var grille_bonus = new Array();
for(var i=0; i<17; i++)
   grille_bonus[i] = new Array();

function init_grille_bonus(){

	//lettre compte double bleu clair - 2
	var tableau1x=[4,7,1,3,7,8,4];	
	var tableau1y=[1,3,4,7,7,4,8];
	for (i=0;i<7;i++){
		grille_bonus[tableau1x[i]][tableau1y[i]]=2;
		grille_bonus[16-tableau1x[i]][tableau1y[i]]=2;
		grille_bonus[tableau1x[i]][16-tableau1y[i]]=2;
		grille_bonus[16-tableau1x[i]][16-tableau1y[i]]=2;	
	}

	//lettre compte double bleu foncé - 3
	var tableau1x=[6,6,2];	
	var tableau1y=[2,6,6];
	for (i=0;i<3;i++){
		grille_bonus[tableau1x[i]][tableau1y[i]]=3;
		grille_bonus[16-tableau1x[i]][tableau1y[i]]=3;
		grille_bonus[tableau1x[i]][16-tableau1y[i]]=3;
		grille_bonus[16-tableau1x[i]][16-tableau1y[i]]=3;
	}

	//mot compte double rose clair - 4
	var tableau1x=[2,3,4,5,8];	
	var tableau1y=[2,3,4,5,8];
	for (i=0;i<5;i++){
		grille_bonus[tableau1x[i]][tableau1y[i]]=4;
		grille_bonus[16-tableau1x[i]][tableau1y[i]]=4;
		grille_bonus[tableau1x[i]][16-tableau1y[i]]=4;
		grille_bonus[16-tableau1x[i]][16-tableau1y[i]]=4;	
	}

	//mot compte triple rouge - 5
	var tableau1x=[1,1,8];	
	var tableau1y=[1,8,1];
	for (i=0;i<3;i++){
		grille_bonus[tableau1x[i]][tableau1y[i]]=5;
		grille_bonus[16-tableau1x[i]][tableau1y[i]]=5;
		grille_bonus[tableau1x[i]][16-tableau1y[i]]=5;
		grille_bonus[16-tableau1x[i]][16-tableau1y[i]]=5;
	}
}
init_grille_bonus();

function traitement_des_resultats(motTesteF,directionF,xF,yF){
	nb_resultat++;
	resultats[nb_resultat][0]=motTesteF;
	resultats[nb_resultat][1]=directionF;
	resultats[nb_resultat][2]=xF;
	resultats[nb_resultat][3]=yF;
	var bonus_mot = 1;
	var valeur_mot = 0;

	for(var i=0; i<motTesteF.length;i++){
		var valeur_lettre = 0;
		if ((motTesteF.charAt(i) == 'a') || (motTesteF.charAt(i) == 'e') || (motTesteF.charAt(i) == 'i') || (motTesteF.charAt(i) == 'l') || (motTesteF.charAt(i) == 'n') || (motTesteF.charAt(i) == 'o') || (motTesteF.charAt(i) == 'r') || (motTesteF.charAt(i) == 's') || (motTesteF.charAt(i) == 't') || (motTesteF.charAt(i) == 'u')){
			valeur_lettre = 1;
		}
		if ((motTesteF.charAt(i) == 'd') || (motTesteF.charAt(i) == 'g') || (motTesteF.charAt(i) == 'm')){
			valeur_lettre = 2;
		}
		if ((motTesteF.charAt(i) == 'b') || (motTesteF.charAt(i) == 'c') || (motTesteF.charAt(i) == 'p')){
			valeur_lettre = 3;
		}
		if ((motTesteF.charAt(i) == 'f') || (motTesteF.charAt(i) == 'h') || (motTesteF.charAt(i) == 'v')){
			valeur_lettre = 4;
		}
		if ((motTesteF.charAt(i) == 'j') || (motTesteF.charAt(i) == 'q')){
			valeur_lettre = 8;
		}
		if ((motTesteF.charAt(i) == 'k') || (motTesteF.charAt(i) == 'w') || (motTesteF.charAt(i) == 'x') || (motTesteF.charAt(i) == 'y') || (motTesteF.charAt(i) == 'z')){
			valeur_lettre = 10;
		}
		

		if (directionF == 1){
			if(grille[xF + i][yF]==0){			//les bonus sont utilisés qu'une seule fois donc que si la case est vide

				if (grille_bonus[xF + i][yF] == 2){
					valeur_lettre = valeur_lettre * 2;
				}
				if (grille_bonus[xF + i][yF] == 3){
					valeur_lettre = valeur_lettre * 3;
				}
				if (grille_bonus[xF + i][yF] == 4){
					bonus_mot = bonus_mot * 2;
				}
				if (grille_bonus[xF + i][yF] == 5){
					bonus_mot = bonus_mot * 3;
				}
			}
			//console_output("    *    " + motTesteF.charAt(i) + " : " +  grille_bonus[xF + i][yF]);
		}
		if (directionF == 2){
			if(grille[xF][yF + i]==0){			//les bonus sont utilisés qu'une seule fois donc que si la case est vide

				if (grille_bonus[xF][yF + i] == 2){
					valeur_lettre = valeur_lettre * 2;
				}
				if (grille_bonus[xF][yF + i] == 3){
					valeur_lettre = valeur_lettre * 3;
				}
				if (grille_bonus[xF][yF + i] == 4){
					bonus_mot = bonus_mot * 2;
				}
				if (grille_bonus[xF][yF + i] == 5){
					bonus_mot = bonus_mot * 3;
				}
			}
			//console_output("    *    " + motTesteF.charAt(i) + " : " + grille_bonus[xF][yF + i]);
		}

		valeur_mot += valeur_lettre;
	}
	valeur_mot = valeur_mot * bonus_mot;

	resultats[nb_resultat][4] = valeur_mot;
	if (valeur_mot > maxPoint){
		maxPoint = valeur_mot;
	}
}





plateau();















/*

Le plateau dont ce script a été fait par : 
	Steve MAHOT
	Yann Abou Jaoude

Le design du site a été fait par :
	Pham Cyril Nguyen

*/



















