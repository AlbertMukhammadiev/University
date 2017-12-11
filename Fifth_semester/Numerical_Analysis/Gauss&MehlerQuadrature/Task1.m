function [ ] = Task1( )
    a = 0;
    b = 0.4;
    n = 5;
    
    intf = IntegralF(a, b);
    for i = 1 : n    
        S = GaussLegendreQuadrature(a, b, i);
        ksi = (a + b) / 2;
        error = (b - a)^(2 * i + 1) * (factorial(i))^4 /...
            (2 * i + 1) / (fix(factorial(2 * n)))^3 * df(ksi, 2 * i);
        actualError = intf - S;
        
        integrals(i) = intf;
        Sums(i) = S;
        actualErrors(i) = actualError;
        theoreticalErrors(i) = error;
    end
    
    integrals = num2cell(integrals);
    Sums = num2cell(Sums);
    actualErrors = num2cell(actualErrors);
    theoreticalErrors = num2cell(theoreticalErrors);
    data = [integrals; Sums; actualErrors; theoreticalErrors];

    rowNames = {'exact value', 'approximation', 'actual error',...
                'theoretical error'};
    columnNames = {'n = 1', 'n = 2', 'n = 3', 'n = 4', 'n = 5'};
    f = figure('Position', [500 500 570 100]);
    t = uitable( f, 'Data', data, 'ColumnName',columnNames,...
                'RowName',rowNames,'Position', [0 0 565 95]);
    print(f, '-dpng', '-r300', 'table_GaussLegendre');

end

