% builds the polinomial of best approximation on [0; 1]
% for f(x) = x^n;
% draws Chebyshev polinomial of n-th degree, approximating function
% and alternance points;
function [ ] = Approximate2( n )
numOfNodes = 101;
dx = 1 / (numOfNodes - 1);
x = 0 : dx : 1;
max = 0;

for i = 1 : numOfNodes
    % function
    fx(i) = x(i) ^ n;
    % Chebyshev polynomial
    Tnx(i) = cos (n * acos(x(i)));
    % approximating function
    y(i) = fx(i) - Tnx(i) / 2 ^ (n - 1);
    
    % searching of a max for search of alternance points
    norm = abs(fx(i) - y(i));
    if norm > max
        max = norm;
    end
end

% alternance points
k = 1;
E = 1 / 100^4;
for i = 1 : numOfNodes
    if ((abs(fx(i) - y(i)) <= max + E) && (abs(fx(i) - y(i)) >= max - E))
        alt(k) = dx * (i - 1);
        k = k + 1;
    end
end

nStr = int2str(n);

hold on;
fPlot = plot(x, fx, 'DisplayName', strrep('f(x)=x^n', 'n', nStr));
TnPlot = plot(x, Tnx, 'DisplayName', strrep('T_n(x)', 'n', nStr));
yPlot =  plot(x, y, 'DisplayName', 'approximating function');
altPlot = plot(alt, 0, 'o', 'DisplayName', 'alternance point');
hold off;

set(fPlot, 'LineWidth', 1.5);
set(TnPlot, 'LineWidth', 1.5);
set(yPlot, 'LineWidth', 1.5);
set(altPlot, 'LineWidth', 2);
legend('show');
end