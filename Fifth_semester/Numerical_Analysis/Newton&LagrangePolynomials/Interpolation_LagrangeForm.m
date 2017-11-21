% draws function and interpolation polinomial
% in the Lagrange form
function [ ] = Interpolation_LagrangeForm( nodesNum )
a = 0; b = 1;

% function
x1 = 0 : 0.001 : 1;
fx = f(x1);

% interpolation
dx = (b - a) / (nodesNum - 1);
x2 = 0 : dx : 1;
for i = 1 : length(x2)
    px(i) = LagrangePolinomial(x2, f(x2), x2(i));
end

h = figure;
title('Interpolation polynomial in the Lagrange form');
hold on;
grid on;
pxPlot = plot(x2, px, '-o', 'DisplayName',...
                strrep('P_{n}(x)', 'n', int2str(nodesNum - 1)));
fxPlot = plot(x1, fx, 'DisplayName', 'sin^5(5x)');
set(pxPlot, 'LineWidth', 1.5);
set(fxPlot, 'LineWidth', 1.5);
legend('show');
print(h, '-dpng', '-r300', 'graph1');
end