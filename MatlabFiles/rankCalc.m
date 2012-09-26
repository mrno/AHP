function [ranking] = rankCalc(cel)
%   Esta función calcula el ranking final AHP para las alternativas

%   Determina el tamaño del cellarray
[f, cant] = size(cel);
[filaux, colaux] = size(cell2mat(cel(2)));
matVectAlter = zeros (filaux, cant- 1);
vectCriterios = zeros (cant - 1, 1);
for iter = 1:cant
    
    Mat = cell2mat(cel(iter));
    [filas, columnas] = size(Mat);
    dimension = filas;

    [autovectores, autovalores] = eig(Mat);

    valores = max(autovalores);
    [autovalor, posicion] = max(valores);
    autovector = autovectores (:, posicion);
    suma = sum(autovector);
    autovector = (autovector / suma);
    
    if (iter == 1)
        vectCriterios = autovector;
    else    
        matVectAlter(:, iter-1) = autovector;
    end
    
end
% *  matVectAlter .. ranking = vectCriterios;

ranking = cell2mat(cel(4));

end