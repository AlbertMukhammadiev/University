% returns the value of the interpolation polynomial in the Lagrange form;
% arguments:
%   x - array of nodes
%   y - value in these nodes
%   x0 - the point at which the value of the polynomial is calculated
function [ y ] = LagrangePolinomial( xs, ys, x)
    if (length(xs) ~= length(ys))
        error('The size of arrays a and b should be the same');
    end

    n = length(ys);
    y = 0;
    for k = 1 : n
        product = 1;
        for j = 1 : n
            if (k == j)
                continue;
            end
            product = product * (x - xs(j)) / (xs(k) - xs(j));
        end

        y = y + ys(k) * product;
end