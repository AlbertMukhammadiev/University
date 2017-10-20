% returns an array of arguments and an array of polynomial values from these arguments
% a - left border, b - right border,
% n - the number of the derivative,
% array - polynomial coefficients
function [ x, y ] = DrawPx( a, b, n, array )
numOfNodes = 51;
dx = (b - a) / (numOfNodes - 1);
for k = 1 : numOfNodes
    result(k) = HornerSchemeDerivative(a + (k - 1) * dx, array, n);
end
x = a : dx : b;
y = result;
end

