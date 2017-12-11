% returns roots of Legendre polynomial
function [ roots ] = GetLegendreRoots( n )
    switch n
        case 1
            roots = 0;
        case 2
            x = sqrt(1 / 3);
            roots = [-x x];
        case 3
            x = sqrt(3 / 5);
            roots = [-x 0 x];
        case 4
            D = sqrt(30 * 30 - 4 * 3 *35);
            t1 = (30 + D) / 70;
            t2 = (30 - D) / 70;
            x1 = sqrt(t1);
            x2 = sqrt(t2);
            roots = [-x1 -x2 x2 x1];
        case 5
            D = sqrt(70 * 70 - 4 * 15 * 63);
            t1 = (70 + D) / 126;
            t2 = (70 - D) / 126;
            x1 = sqrt(t1);
            x2 = sqrt(t2);
            roots = [-x1 -x2 0 x2 x1];
        otherwise
            roots = 0;
            Display('Incorrect argument(n should be 1..5)');
    end
end