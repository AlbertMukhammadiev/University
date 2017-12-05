% draws the dependence of errors on the number of nodes
function [ ] = DrawDependenceForTR( )
    a = 0;
    b = 0.4;
    xs = 5 : 1 : 21;
    xs4 = 5 : 4 : 21;
    
    for k = 5 : 21
        [S error] = TrapezoidRule(a, b, k);
        actualErrors(k - 4) = IntegralF(a, b) - S;
        theoreticalErrors(k - 4) = error;
        
        if (mod(k, 4) == 1)
            [S2 temp] = TrapezoidRule(a, b, k);
            RungeEstimates(floor(k / 4)) = (S2 - S) / 3;
        end
    end
    
    %f = figure;
    title('Trapezoid rule');
    hold on;
    grid on;
    actErrPlot = plot(xs, actualErrors, 'DisplayName', 'Actual errors(TR)');
    theorErrPlot = plot(xs, theoreticalErrors, 'DisplayName', 'Theoretical errors(TR)');
    RungePlot = plot(xs4, RungeEstimates, 'DisplayName', 'Runge estimate(TR)');
    set(actErrPlot, 'LineWidth', 1.5);
    set(theorErrPlot, 'LineWidth', 1.5);
    set(RungePlot, 'LineWidth', 1.5);
    legend('show');
    %print(f, '-dpng', '-r300', 'TrapezoidRule');
end