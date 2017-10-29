% builds the polinomial of best approximation and
% returns the best approximation on [0; 1] for f(x) = 1 / sqrt(1 + x);
% draws function, chord between points 0 and 1,
% tangent line, that is parallel to the chord and required polinomial;
function [ bestapprox ] = ApproximateP1x(  )
k = (f(1) - f(0))/(1 - 0);
% The point at which the tangent line is parallel to the chord
x0 = 1 / (-2 * k)^(2 / 3) - 1;
y0 = f(x0);
% Drawing:
numOfNodes = 101;
dx = 1 / (numOfNodes - 1);
x = 0 : dx : 1;
% function
for i = 1 : numOfNodes
    y(i) = f((i - 1) * dx);
end
% tangent
for i = 1 : numOfNodes
    y_t(i) = (x(i) - x0) * k + y0;
end
% chord
for i = 1 : numOfNodes
    y_c(i) = x(i) * k + f(0);
end
% polinomial of best approximation of the first degree
temp = -x0 * k + y0;
for i = 1 : numOfNodes
    P1x(i) = x(i) * k + (f(0) + temp) / 2;
end

p = plot(x, y, 'k-', x, y_t, 'c--', x, y_c, 'b--', x, P1x, 'g-');
legend('1/sqrt(1 + x)', 'tangent', 'chord', 'P_1(x)');
set(p, 'LineWidth', 1.5);

% search for best approximation(by C-norm)
max = 0;
for i = 1 : numOfNodes
    norm = abs(P1x(i) - y(i));
    if norm > max
        max = norm;
    end
end

bestapprox = max;
end