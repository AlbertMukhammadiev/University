% Draws functions and point of approximation
% Draws graph of actual error decreasing
% arguments:
%   fs - array of string representation of the functions
%   eps - the upper bound on the relative error, which affects the quality
%       of the approximation
function [ ] = DrawError(fs, eps )
    figure1 = figure;
    hold on;
    grid on;
    xs = sym('x', [length(fs) 1]);
    F = [];
    for i = 1 : length(fs)
        f = symfun(sym(fs(i)), xs);
        ezplot(f);
        F = [F; f];
    end
    
    sln = solve(F);
    sln = vpa([sln.x1; sln.x2]);
    approximations = NewtonMethod(F, sln - [1; 1], sln, eps);
    bestApprox = approximations(:, length(approximations));
    plot(bestApprox(1), bestApprox(2), 'ro', 'LineWidth', 1.5);
    title('Approximation');
    print(figure1, '-dpng', '-r300', 'Approximation');
    
    figure2 = figure;
    xs = 1 : 1 : length(approximations);
    for i = 1 : length(approximations)
        errors(i) = EuclideanDistance(approximations(:, i), sln);
    end
    title('Graph Of Error');
    semilogy(xs, errors, 'LineWidth', 1.5);
    print(figure2, '-dpng', '-r300', 'GraphOfError');
end