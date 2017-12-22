function [ ] = GraphsOfConvergence( )
newtonxs = NewtonMethod('sin(x) - exp(-x)', 0, 10);

chordxs = ChordMethod('sin(x) - exp(-x)', 0, 3, 10);

directxs = DirectInterpolation( 'sin(x) - exp(-x)', 0, 1, 2);

inversexs = InverseFunctionToTaylor( 'sin(x) - exp(-x)', 0 );

inverseQxs = InverseQuadraticInterpolation( 'sin(x) - exp(-x)', 0, 1, 2);
n = 7;
xs = 1 : 1 : n;
hold on;
plot(xs, newtonxs(1 : n))
plot(xs, chordxs(1 : n))
plot(xs, directxs(1 : n))
plot(xs, inversexs(1 : n))
plot(xs, inverseQxs(1 : n))

% Представить на одном рисунке графики сходимости различных методов.
% По оси абсцисс – номер шага алгоритма, по оси ординат – фактическая погрешность.
% Ось ординат представить в логарифмическом масштабе. 
% Начальное приближение найти графически.
% Варианты заданий:

end

