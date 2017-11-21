% returns the value of the interpolation polynomial in the Newton form
% arguments:
%   x - array of nodes
%   Y - matrix of divided differences
%   x0 - the point at which the value of the polynomial is calculated
function [ y0 ] = NewtonPolinomial( x, Y, x0 )
    y0 = 0;
    z = 1;
    for i = 1 : length(x)
        y0 = y0 + Y(1, i) * z;
        z = z * (x0 - x(i));
    end
end