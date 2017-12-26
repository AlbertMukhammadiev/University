% returns array of errors in order:
%   1) theoretical(periodic) error
%   2) theoretical error
%   3) actual error
%   4) Runge estimate
% arguments:
%   f - function
%   max_d2f - max second derivative on [a; b]
%   [a; b] - interval
%   n - number of nodes
%   T - period
function [ errors ] = GetErrors( f, max_d2f, a, b, n, T )
    % theoretical(periodic) error
    accuracyDeg = 6;
    An = 0;
    for k = 1 : accuracyDeg
        a_n = vpa(2 / T * int(f * cos(2 * pi * k * n * sym('x') / T), sym('x'), a, b));
        b_n = vpa(2 / T * int(f * sin(2 * pi * k * n * sym('x') / T), sym('x'), a, b));
        An = An + sqrt(a_n^2 + b_n^2);
    end
    errors(1) = vpa(pi * An);
    
    % theoretical error
    errors(2) = vpa((b - a) * ((b - a) / n) ^ 2 * max_d2f / 24);
    
    % actual error
    S = RiemannSum(f, a, n, T);
    I = int(f, sym('x'), a, T);
    errors(3) = vpa(abs(S - I));
    
    % Runge estimate
    errors(4) = vpa(abs(S - RiemannSum(f, a, 2 * n, T)));
end












