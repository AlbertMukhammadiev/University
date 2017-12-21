% returns array of errors in order:
%   1) theoretical(periodic) error
%   2) theoretical error
%   3) actual error
%   4) Runge estimate
% arguments:
%   func - function
%   a - left boarder
%   n - number of nodes
%   T - period
function [ errors ] = GetErrors( func, a, n, T )
    accuracy = 15;
    
    % theoretical(periodic) error
    a_n = 2 / T * int(func * cos(2 * pi * n * sym('x') / T), sym('x'), a, T);
    b_n = 2 / T * int(func * sin(2 * pi * n * sym('x') / T), sym('x'), a, T);
    An = sqrt(a_n^2 + b_n^2);
    errors(1) = vpa(pi * An, accuracy);
    
    % theoretical error 
    d2f = symfun(diff(diff(func, sym('x'))), sym('x'));
    x = a;
    b = a + T;
    dx = 1 / 100;
    max_d2f = -inf;
    while x < b
        temp = abs(d2f(x));
        if temp > max_d2f
            max_d2f = temp;
        end
        x = x + dx;
    end
    max_d2f = eval(max_d2f);
    errors(2) = vpa((b - a) * ((b - a) / n) ^ 2 * max_d2f / 24, accuracy);
    
    % actual error
    S = RiemannSum(func, a, n, T);
    I = int(func, sym('x'), a, T);
    errors(3) = vpa(S - I, accuracy);
    
    % Runge estimate
    errors(4) = vpa(S - RiemannSum(func, a, 2 * n, T), accuracy);
end












