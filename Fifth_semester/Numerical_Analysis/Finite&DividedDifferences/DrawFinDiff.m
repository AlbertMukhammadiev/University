% draws table of finite differences with arguments:
% [a,b] - definition area
% n - number of nodes
function [ ] = DrawFinDiff( a, b, n )
delta = FiniteDifferences(a, b, n, n - 1);
for i = 1 : n
    name(i) = "x" + int2str(i);
end

fxTable = table(name', delta(:,1));
fxTable.Properties.VariableNames([1 2]) = {'x' 'f'};
delta(:,1) = [ ];
deltaTable = array2table(delta);
fxTable = [fxTable deltaTable];
display(fxTable);
end

