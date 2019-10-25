function nb_aleatoire(min, max) //Une fonction très utile pour gagner du temps !! :D
{
     var nb = min + (max-min+1)*Math.random();
     return Math.floor(nb);
}

function main(form1) {
	var nbmystere=document.form1.nbmystere.value
	var saisie=document.form1.input.value;
	//alert("Le nb est :" + saisie);
	if(saisie > nbmystere){
		document.form1.output.value="C'est moins";
	}
	else if(saisie < nbmystere){
		document.form1.output.value="C'est plus";
	}
	else {
		document.form1.output.value="Bravo!";
	}
	document.form1.input.value = "";
	if(saisie >= 100){
		document.form1.output.value="C'est moins";
	}
}

function start(form1){
	var min=0;
	var max=100;
	document.form1.output.value = "";
	document.form1.input.value = "";
	document.form1.nbmystere.value=nb_aleatoire(min, max);
	//alert("reset");
}