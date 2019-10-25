

N=10;

resAbs=zeros(N);
resOrd=zeros(N);

function [y]= f(x)
    y= cos(x);
endfunction

function y=Trapeze(resAbs,resOrd,a,b,N)
    for i=a:(b-a)/(N-1):b
        resAbs(i )= i;
        resOrd(i) = f(i);
    end
    y=1
endfunction

y=Trapeze(resAbs,resOrd,0,2,N);

//v = inttrap(resAbs, resOrd)
