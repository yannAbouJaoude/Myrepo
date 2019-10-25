// Yann Abou Jaoude
//1
A=[1, 2, 3] 
P1 = poly(A, "s", "coeff") 
P2 = poly(A, "x", "roots")
//P1+P2
P1*P2

//2
A=2+4*%s^3+(1*%s-2)*(1*%s+4)*(1*%s^3+6*%s+1)

//3
function [coef]=saisie_coef(nc)//demande des coefficients polynome
    coef=linspace(0,0,nc); 
    for d=1:nc 
        disp("Degree " + string(d-1) + ": "); 
        coef(d)=input(""); 
    end 
endfunction

function [P]=saisie_polynome()//demande degré polynome
    disp("Creer un nouveau polynome "); 
    deg=input("Degree = ? "); 
    ncoef=deg+1; 
    coef_P=saisie_coef(ncoef); 
    P=poly(coef_P,"x","coeff"); 
endfunction

saisie_polynome()

//4
function [A]=genere_coeff()
    disp("Creer un nouveau polynome ");
    A=1;
    deg=input("Degree = ? "); 
    for i=1:deg
        racine=input("racine = ?");
        A=(%s-racine)*A;
    end
    A
endfunction

//5
function Tracer_Courbe(a, b, P) 
    Xmin = min(a, b) ; 
    Xmax = max(a, b) ;
    x = Xmin : 0.01 : Xmax; 
    y = horner(P, x);
    clf; 
    plot(x,y,b) 
endfunction

function Tracer_Courbe2(a, b, P) 
    Xmin = min(a, b) ; 
    Xmax = max(a, b) ;
    x = Xmin : 0.01 : Xmax; 
    y = horner(P, x);
    y=sin(y)
    clf; 
    plot(x,y,b) 
endfunction

a=-5;
b=5;
P=poly([1,-2,1],"x","coeff")
P2=poly([0,3,1],"x","coeff")
Tracer_Courbe(a,b,P)
Tracer_Courbe2(a,b,P2)

s=[0:0.1:10]';
plot(sin(s**2+3*s))

//II
function y=Factorielle(N)
    y=1;
    for i=1:N
        y=y*i;
    end
    y
endfunction

function p=Interpol_Lagrange(X, Y)
n = length(X); 
p = 0; 
x = poly(0, "x"); // polynome "x"
for(i=1:n) L=1; 
    for(j=1:n) 
        if(i<>j) Q=(x- X(j))/( X(i)-X(j) ); L=L*Q; 
            end
         end 
        p=p+Y(i)*L; 
      end
endfunction
