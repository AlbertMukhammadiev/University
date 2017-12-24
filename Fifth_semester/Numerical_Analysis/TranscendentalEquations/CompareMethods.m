% Draws graph of convergence of various methods
% arguments:
%   func - string representation of the function
%   n - quantity of steps of the algorithm
%   stepNo - starting with the 'stepNo' actual error is observed
function [ ] = CompareMethods( func, n, stepNo )
root = solve(func);
eps = sym(1 / 10^15);
x1 = 0;
x2 = 1;
x3 = 2;
xsNewton = NewtonMethod(func, x1, eps);
xsChord = ChordMethod(func, x1, x2, eps);
xsQuadratic = QuadraticInterpolation(func, x1, x2, x3, eps);
xsInvQuadratic = InverseQuadraticInterpolation(func, x1, x2, x3, eps);
xsChebyshev = ChebyshevMethod(func, x1, eps);
xsTaylor = TaylorMethod(func, x1, eps);

xs = 1 : 1 : n + stepNo;
root = Extend(root, n + stepNo);
xsNewton = root - Extend(xsNewton, n + stepNo);
xsChord = root - Extend(xsChord, n + stepNo);
xsQuadratic = root - Extend(xsQuadratic, n + stepNo);
xsInvQuadratic = root - Extend(xsInvQuadratic, n + stepNo);
xsChebyshev = root - Extend(xsChebyshev, n + stepNo);
xsTaylor = root - Extend(xsTaylor, n + stepNo);

lineWidth = 1.5;
f = figure;
grid on;
hold on;
title('Methods of solving Transcendental equations');
semilogy(xs(1 + stepNo : n + stepNo), xsNewton(1 + stepNo : n + stepNo),...
        'LineWidth', lineWidth,...
        'DisplayName', 'Newton method');
semilogy(xs(1 + stepNo : n + stepNo), xsChord(1 + stepNo : n + stepNo),...
        'LineWidth', lineWidth,...
        'DisplayName', 'Chord method');
semilogy(xs(1 + stepNo : n + stepNo), xsQuadratic(1 + stepNo : n + stepNo),...
        'LineWidth', lineWidth,...
        'DisplayName', 'Quadratic interpolation method');
semilogy(xs(1 + stepNo : n + stepNo), xsInvQuadratic(1 + stepNo : n + stepNo),...
        'LineWidth', lineWidth,...
        'DisplayName', 'Inverse Quadratic interpolation method');
semilogy(xs(1 + stepNo : n + stepNo), xsChebyshev(1 + stepNo : n + stepNo),...
        'LineWidth', lineWidth,...
        'DisplayName', 'Chebyshev method');
semilogy(xs(1 + stepNo : n + stepNo), xsTaylor(1 + stepNo : n + stepNo),...
        'LineWidth', lineWidth,...
        'DisplayName', 'Taylor method');
legend('show');
fileName = strrep('GraphOfConvergence(since*)', '*', int2str(stepNo));
print(f, '-dpng', '-r300', fileName);
end