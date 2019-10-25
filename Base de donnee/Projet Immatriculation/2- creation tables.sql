USE `loueur`;

CREATE TABLE `loueur`.`client` (
  `codeC` VARCHAR(4) NOT NULL,
  `nom` VARCHAR(20) NOT NULL,
  `prenom` VARCHAR(20) NULL,
  `age` INT NULL,
  `permis` VARCHAR(10) NULL,
  `adresse` VARCHAR(50) NULL,
  `ville` VARCHAR(20) NULL,
  PRIMARY KEY (`codeC`) );
  
CREATE TABLE `loueur`.`proprietaire` (
  `codeP` VARCHAR(4) NOT NULL,
  `pseudo` VARCHAR(20) NOT NULL,
  `email` VARCHAR(20) NULL,
  `ville` VARCHAR(20) NULL,
  `anneeI` VARCHAR(4) NULL,
  PRIMARY KEY (`codeP`) );
  
CREATE TABLE `loueur`.`voiture` (
  `immat` VARCHAR(10) NOT NULL,
  `modele` VARCHAR(20) NULL,
  `marque` VARCHAR(20) NULL,
  `categorie` VARCHAR(20) NULL,
  `couleur` ENUM('blanc','rouge','vert','noir','violet','bleu'),
  `places` INT NULL CHECK (places <= 6),
  `achatA` VARCHAR(4) NULL,
  `compteur` INT NOT NULL,
  `prixJ` INT NULL,
  `codeP` VARCHAR(4) NULL,
  PRIMARY KEY (`immat`),
   INDEX `F_voit1_idx` (`codeP` ASC),
   CONSTRAINT `codePVoiture` FOREIGN KEY (`codeP`)
		REFERENCES `loueur`.`proprietaire` (`codeP`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION );
 
CREATE TABLE `loueur`.`location` (
  `codeC` VARCHAR(4) NOT NULL,
  `immat` VARCHAR(10) NOT NULL,
  `annee` VARCHAR(4) NOT NULL,
  `mois` VARCHAR(2) NOT NULL,
  `numLoc` VARCHAR(5) NULL,
  `km` INT NOT NULL,
  `duree` INT NULL,
  `villeD` VARCHAR(20) NULL,
  `villeA` VARCHAR(20) NULL,
  `dateD` DATE NULL,
  `dateF` DATE NULL,
  PRIMARY KEY (`codeC`, `immat`, `annee`, `mois`),
   INDEX `F_loc1_idx` (`codeC` ASC),
   INDEX `F_loc2_idx` (`immat` ASC),
   INDEX `F_loc3_idx` (`numLoc` ASC),
   CONSTRAINT `codeCLocation` FOREIGN KEY (`codeC`)
		REFERENCES `loueur`.`client` (`codeC`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
  CONSTRAINT `immatLocation` FOREIGN KEY (`immat`)
		REFERENCES `loueur`.`voiture` (`immat`)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION  );