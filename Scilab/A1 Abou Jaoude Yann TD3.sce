//EXERCICE I

function derivey=y1(t,y),
 derivey=-y+t+1;
endfunction 
function solution=sy1(t)
    solution = t+exp(-t);
endfunction

function [t, y] = Euler(a,b, N, alpha, f)
    h = (b-a)/N;
    t(1) = a;
    y(1) = alpha;
    i = 1;
    for i=1:N
        y(i+1)= y(i)+h*f(t(i), y(i) );
        t(i+1)= t(i) + h;
    end
endfunction
function [t,y] = heun(a,b,n,alpha,f)
h = (b - a) / n;
halfh = h / 2;
y(1) = alpha;
t(1) = a;
for i = 1 : n
    t(i+1) = t(i) + h;
    g = f(t(i),y(i));
    z = y(i) + h * g;
    y(i+1) = y(i) + halfh * ( g + f(t(i+1),z) );
end;
endfunction
function [t,y] = rk4(a,b,n,alpha,f)
h = (b - a) / n;
halfh = h / 2;
y(1) = alpha;
t(1) = a;
h6 = h/6;
for i = 1 : n
    t(i+1) = t(i) + h;
    th2 = t(i) + halfh;
    s1 = f(t(i), y(i));
    s2 = f(th2, y(i) + halfh * s1);
    s3 = f(th2, y(i) + halfh * s2);
    s4 = f(t(i+1), y(i) + h * s3);
    y(i+1) = y(i) + (s1 + s2+s2 + s3+s3 + s4) * h6;
end;
endfunction
Alpha=1;
A=0
B=5
//N=10
//N=100
N=1000
//Quand nous augmentons le n 10X, nous reduisonsl'erreur environ 100X
[t,y2]=Euler(A,B,N,Alpha,y1)
[t,y3]=heun(A,B,N,Alpha,y1);
[t,y4]=rk4(A,B,N,Alpha,y1);

sol(1)=sy1(t(1));
for i = 1:N+1
    sol(i) = sy1(t(i));
end

subplot(121);
plot(t,sol,'k-');
subplot(121);
plot(t,y2,'b-');
subplot(121);
plot(t,y3,'g-');
subplot(121);
plot(t,y4,'r-');

subplot(122);
erreur = abs(y2-sol);
plot(t,log(erreur),'b-');
subplot(122);
erreur = abs(y3-sol);
plot(t,log(erreur),'g-');
subplot(122);
erreur = abs(y4-sol);
plot(t,log(erreur),'r-');
  
legend(['Log erreur euler','Log erreur heun','Log erreur rk4'],pos = "2");
  
