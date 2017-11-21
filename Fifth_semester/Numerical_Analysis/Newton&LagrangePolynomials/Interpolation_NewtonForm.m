% draws function and interpolation polinomial
% in the Newton form
function [ ] = Interpolation_NewtonForm( nodesNum )
a = 0; b = 1;

% function
x1 = 0 : 0.001 : 1;
fx = f(x1);

% interpolation
dx = (b - a) / (nodesNum - 1);
x2 = 0 : dx : 1;
Y = DividedDifferences(x2, f(x2), length(x2));
for i = 1 : length(x2)
    px(i) = NewtonPolinomial(x2, Y, x2(i));
end

h = figure;
title('Interpolation polynomial in the Newton form');
hold on;
grid on;
pxPlot = plot(x2, px, '-o', 'DisplayName',...
                strrep('P_{n}(x)', 'n', int2str(nodesNum - 1)));
fxPlot = plot(x1, fx, 'DisplayName', 'sin^5(5x)');
set(pxPlot, 'LineWidth', 1.5);
set(fxPlot, 'LineWidth', 1.5);
legend('show');
print(h, '-dpng', '-r300', 'graph2');
end