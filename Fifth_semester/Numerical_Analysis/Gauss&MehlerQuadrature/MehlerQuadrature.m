function [ S ] = MehlerQuadrature( n )
    S = 0;
    for k = 1 : n
        % i-th root of n-th Chebyshev polynomial
        root = cos((2 * k - 1) * pi / 2 / n);
        S = S + f(root);
    end
    
    S = S * pi / n;
end

