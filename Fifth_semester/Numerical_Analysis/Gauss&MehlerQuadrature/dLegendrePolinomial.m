function [ dPnx ] = dLegendrePolinomial( x, n )
    P = [0 x];
    coeff1 = x * (2 * n + 1) / (n + 1);
    coeff2 = n / (n + 1);
    for k = 1 : n - 1
        P(k + 1) = coeff1 * P(k) - coeff2 * P(k - 1);
    end
    dPnx = n / (1 - x^2) * (P(n - 1) - x * P(n));
end