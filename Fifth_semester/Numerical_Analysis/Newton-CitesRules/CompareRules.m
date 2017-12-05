% draws a comparative table for rules for calculating the integral
function [ ] = CompareRules( )
    a = 0;
    b = 0.4;
    n = 5;
    
    [S1, err1] = MidpointRule(a, b, n);
    [S2, err2] = TrapezoidRule(a, b, n);
    [S3, err3] = SimpsonsRule(a, b, n);
    
    exactV = IntegralF(a, b);
    exactValues = {exactV, exactV, exactV};
    approxs = {S1, S2, S3};
    actualErr = {exactV - S1, exactV - S2, exactV - S3};
    theoreticalErr = {err1, err2, err3};
    
    [S12, temp] = MidpointRule(a, b, ceil(n / 2));
    [S22, temp] = TrapezoidRule(a, b, ceil(n / 2));
    [S32, temp] = SimpsonsRule(a, b, ceil(n / 2));
    ruki = {(S12 - S1) / 3, (S22 - S2) / 3, (S32 - S3) / 15};
    
    data = [exactValues; approxs; actualErr; theoreticalErr; ruki];

    rowNames = {'exact value', 'approximation', 'actual error',...
                'theoretical error', 'Runge estimate'};
    columnNames = {'Midpoint rule', 'Trapezoid rule', 'Simpson''s rule'};
    f = figure;
    t = uitable( f, 'Data', data, 'ColumnName',columnNames,...
                'RowName',rowNames,'Position', [20 20 430 120]);
    %print(f, '-dpng', '-r300', 'table');
end