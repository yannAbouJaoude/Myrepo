//Abou Jaoudé Yann TDA
//1
A=[1,2,3];
P1=poly(A,"s", "coeff");
P2=poly(A,"x", "roots");
//P1 + P2 impossible si les variables sont différentes.
//P1*P2 possible mais on voit que la variable de l'un des polynomes 
//s'est transmuté.
//2
B = [2,0,0,4];
C=[-2,1];
D = [4,1];
E = [1,6,0,1];

PB = poly(B,"x", "coeff");
PC = poly(C,"x", "coeff");
PD = poly(D,"x", "coeff");
PE = poly(E,"x", "coeff");

P = PB+PC*PD*PE;

//3

function[coef]=saisie_coef(nc)
    coef=linspace(0,0,nc);
    for d=1:nc
        disp("degree "+string(d-1)+ ": ");
        coef(d)=input("");
    end
endfunction

function [P]=saisie_polynome()
    disp("creer un nouveau polynome ");
    deg=input("Degree = ?");
    ncoef=deg+1;
    coef_P=saisie_coef(ncoef);
    P=poly(coef_P,"x","coeff")
endfunction

//4
function [P]=creer_polynome()
    disp("creer un nouveau polynome ");
    deg=input("Degree = ?");
    ncoef=deg+1;
    coef_P=saisie_coef(ncoef);
    P=poly(coef_P,"x","roots")
endfunction
//5
function courbe(a,b,P)
    Xmin=min(a,b);
    Xmax=max(a,b);
    x=Xmin:0.01:Xmax;
    y=horner(P,x);
    
    clf;
    plot(x,y,'b')
endfunction
//courbe(-5,5,%s**2-2*%s+1)
function courbeSin(a,b,P)
    Xmin=min(a,b);
    Xmax=max(a,b);
    x=Xmin:0.01:Xmax;
    y=sin(horner(P,x));
    
    clf;
    plot(x,y,'b')
endfunction
//courbeSin(0,10,%s**2+3*%s)

//II
function y=Factorielle(N)
       if N<=1 then
           y=1
           else
           y=N*Factorielle(N-1)
       end
   
endfunction
