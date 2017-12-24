% approximates the root of the transcendental equation using the Chord
%   method
% arguments:
%   func - string representation of the function
%   [a, b] - interval
%   eps - the upper bound on the relative error, which affects the quality
%       of the approximation
function [ xs ] = ChordMethod( func, a, b, eps )
    f = symfun(sym(func), sym('x'));
    fa = eval(f(a));
    fb = eval(f(b));
    if (fa * fb > 0)
        display('points are chosen incorrectly');
        return;
    end
    
    df = symfun(diff(func, sym('x')), sym('x'));
    min = +inf;
    max = -inf;
    dx = 0.1;
    x = a;
    while (x < b)
        x = x + dx;
        temp = eval(abs(df(x)));
        if (temp < min)
            min = temp;
        end
        if (temp > max)
            max = temp;
        end
    end
    
    k = 1;
    condition = true;
    d2f = symfun(diff(df, sym('x')), sym('x'));
    xs(k) = b;
    while condition
        xs(k + 1) = eval(xs(k) - f(xs(k)) * (xs(k) - a) / (f(xs(k)) - fa));
        k = k + 1;
        condition = ((max - min) / min * abs(xs(k) - xs(k - 1)) > eps);
    end
%     if (xor((fb > 0), (d2f((a + b) / 2) < 0)))
%         xs(k) = a;
%         while condition
%             xs(k + 1) = eval(xs(k) - f(xs(k)) * (b - xs(k)) / (fb - f(xs(k))));
%             k = k + 1;
%             condition = ((max - min) / min * abs(xs(k) - xs(k - 1)) > eps);
%         end
%     else
%         xs(k) = b;
%         while condition
%             xs(k + 1) = eval(xs(k) - f(xs(k)) * (xs(k) - a) / (f(xs(k)) - fa));
%             k = k + 1;
%             condition = ((max - min) / min * abs(xs(k) - xs(k - 1)) > eps);
%         end
%         return;
%     end
end