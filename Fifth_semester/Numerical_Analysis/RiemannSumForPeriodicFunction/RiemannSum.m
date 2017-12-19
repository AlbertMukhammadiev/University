function [ S ] = RiemannSum( func, n, T )
syms x;
S = 2 * int(func, x, 0, T) / T;
for k = 1 : n
    t = 2 * pi * n * x / T;
    a_k = 2 * int(func * cos(t), x, 0, T) / T;
    b_k = 2 * int(func * sin(t), x, 0, T) / T;
    A_k = sqrt(a_k ^ 2 + b_k ^ 2);
    S = S + A_k;
end
    
S = vpa(S, 15);
end

