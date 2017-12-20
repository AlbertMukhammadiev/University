function [ S, R ] = RiemannSum( func, n, T )
S = 2 * int(func, sym('x'), 0, T) / T;

for k = 1 : n
    t = 2 * pi * k * sym('x') / T;
    a_k = 2 * int(func * cos(t), sym('x'), 0, T) / T;
    b_k = 2 * int(func * sin(t), sym('x'), 0, T) / T;
    A_k = sqrt(a_k ^ 2 + b_k ^ 2);
    S = S + A_k;
    
    t = 2 * pi * (-k) * sym('x') / T;
    a_k = 2 * int(func * cos(t), sym('x'), 0, T) / T;
    b_k = 2 * int(func * sin(t), sym('x'), 0, T) / T;
    A_k = sqrt(a_k ^ 2 + b_k ^ 2);
    S = S + A_k;
    
    R = pi * A_k;
end
    
S = vpa(S, 15);
end