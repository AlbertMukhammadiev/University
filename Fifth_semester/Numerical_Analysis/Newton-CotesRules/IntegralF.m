% exact calculation of the integral
function [ result ] = IntegralF( a, b )
    result = 2 * (sqrt(1 + b) - sqrt(1 + a));
end