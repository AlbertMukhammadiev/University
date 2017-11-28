; -------------------------------------------------------------------------------------	;
;	Лабораторная работа №n по курсу Программирование на языке ассемблера				;
;	Вариант №vv.																		;
;	Выполнил студент Name.																;
;																						;
;	Исходный модуль LabAssignment.asm													;
;	Содержит функции на языке ассемблера, разработанные в соответствии с заданием		;
; -------------------------------------------------------------------------------------	;
;	Задание: Реализовать прямое и обратное преобразования Фурье
;	Формат данных сигнала: double
;	Формат данных спектра: double
;	Размер (количество отсчетов) сигнала и спектра: 8
;	Способ реализации: DFT4x4 + бабочка
;	Отсчеты спектра являются комплексными числами. Причем действительные части хранятся
;	в первой половине массива, а мнимые - во второй
.DATA
_2			real8 2.0
quaver		real8 0.125
.CODE
; -------------------------------------------------------------------------------------	;
; void CalculateSpectrum(spectrum_type* Spectrum, signal_type* Signal)					;
;	Прямое преобразование Фурье. Вычисляет спектр Spectrum по сигналу Signal			;
;	Типы данных spectrum_type и signal_type, а так же разимер сигнала					;
;	определяются в файле Tuning.h														;
; -------------------------------------------------------------------------------------	;
CalculateSpectrum PROC	; [RCX] - Spectrum
						; [RDX] - Signal
	;	AB = a + b
	;	ab = a - b

	; set e, f, g, h combinations:

	fld		real8	ptr	[rdx]
	fld		st(0)
	fld		real8	ptr	[rdx + 32]
	fadd	st(2),	st(0)
	fsubp										;	eg		EG	

	fld		real8	ptr	[rdx + 16]
	fld		st(0)
	fld		real8	ptr	[rdx + 48]
	fadd	st(2),	st(0)
	fsubp										;	fh		FH		eg		EG
	


	; search of X[2].re and X[6].re

	fld		st(3)
	fsub	st(0),	st(2)						;	EGmFH 	fh		FH		eg		EG
	fst		real8	ptr [rcx + 16]				;	X[2].re
	fstp	real8	ptr [rcx + 48]				;	X[6].re
	
	; FH and EG	aren't necessary any more		;	fh		FH		eg		EG
	fxch	st(3)
	faddp										;	EG+FH	eg		fh

	; set a, b, c, d combinations:

	fld		real8	ptr	[rdx + 8]
	fld		st(0)
	fld		real8	ptr	[rdx + 40]
	fadd	st(2),	st(0)
	fsubp										;	ac		AC		EG+FH	eg		fh

	fld		real8	ptr	[rdx + 24]
	fld		st(0)
	fld		real8	ptr	[rdx + 56]
	fadd	st(2),	st(0)
	fsubp										;	bd		BD		ac		AC		EG+FH	eg		fh



	; search of X[2].im and X[6].im

	fld		st(1)
	fsub	st(0),	st(4)						;	BD-AC	bd		BD		ac		AC		EG+FH	eg		fh
	fst		real8	ptr	[rcx + 80]				;	X[2].im
	fchs
	fstp	real8	ptr	[rcx + 112]				;	X[6].im

	; AC and BD	aren't necessary any more		;	bd		BD		ac		AC		EG+FH	eg		fh
	fxch	st(3)
	faddp										;	ACBD	ac		bd		EG+FH	eg		fh


	; X[2] and X[6] are ready!!
	
	; search of	X[0].re and X[4].re

	fld		st(0)								
	fadd	st(0),	st(4)						; ACBDEGFH	ACBD	ac		bd		EG+FH	eg		fh
	fstp	real8	ptr	[rcx]					;	X[0].re
	fsubp	st(3), st(0)						;	ac		bd	EGFH-ACBD	eg		fh	
	fxch	st(2)
	fstp	real8	ptr	[rcx + 32]				;	X[4].re
												;	bd		ac		eg		fh

	; X[0] and X[4]	are ready!!		X[0].im = X[4].im = 0



	;	R = w * (ac - bd)
	;	I = w * (ac + bd)
	;	w = sqrt(2) / 2

	fld		st(1)								;	ac		bd		ac		eg		fh
	fld		st(1)								;	bd		ac		bd		ac		eg		fh
	fsubp	st(3),	st(0)						;  	ac		bd	  ac-bd		eg		fh
	faddp										;  ac+bd   ac-bd	eg		fh

	fld		_2
	fsqrt
	fdiv	_2									;	w	   ac+bd   ac-bd	eg		fh

	fmul	st(2),	st(0)						;	w	   ac+bd	R		eg		fh
	fmulp										;	I		R		eg		fh

	fxch	st(2)								;	eg		R		I		fh

	fadd	st(0),	st(1)
	fst		real8	ptr	[rcx + 8]				;	X[1].re
	fst		real8	ptr	[rcx + 56]				;	X[7].re

	fsub	st(0),	st(1)
	fxch	st(1)
	fsubp
	fst		real8	ptr	[rcx + 24]				;	X[3].re
	fstp	real8	ptr	[rcx + 40]				;	X[5].re

	fld		st(1)								;	fh		I		fh
	fadd	st(0),	st(1)
	fst		real8	ptr	[rcx + 120]				;	X[7].im
	fchs
	fstp	real8	ptr	[rcx + 72]				;	X[1].im

	fsubp
	fst		real8	ptr	[rcx + 88]				;	X[3].im
	fchs
	fstp	real8	ptr	[rcx + 104]				;	X[5].im

	
	ret
CalculateSpectrum ENDP
; -------------------------------------------------------------------------------------	;
; void RecoverSignal(signal_type* Signal, spectrum_type* Spectrum)						;
;	Обратное преобразование Фурье. Вычисляет сигнал Signal по спектру Spectrum			;
;	Типы данных spectrum_type и signal_type, а так же размер сигнала					;
;	определяются в файле Tuning.h														;
; -------------------------------------------------------------------------------------	;
RecoverSignal PROC	; [RCX] - Signal
					; [RDX] - Spectrum
	
	;	X = [a + a'i, b + b'i, c + c'i, d + d'i, e + e'i, f + f'i, g + g'i, h + h'i]
	;	AB = a + b
	;	ab = a - b
	
	fld		real8	ptr	[rdx + 8]
	fld		real8	ptr	[rdx + 56]
	faddp
	fld		real8	ptr	[rdx + 24]
	fld		real8	ptr	[rdx + 40]
	faddp										;	FD		BH
	
	;	R = b + h + d + f
	;	S = b + h - d - f
	fld		st(1)
	fld		st(1)
	fsubp	st(3),	st(0)
	faddp										;	R		S

	fld		real8	ptr	[rdx + 16]
	fld		real8	ptr	[rdx + 48]
	faddp										;	CG		R		S

	fld		real8	ptr	[rdx + 32]
	fld		real8	ptr	[rdx]
	fld		st(1)
	fld		st(1)
	faddp	st(3),	st(0)
	fsubp										;	ae		AE		CG		R		S

	
	;	search of x[0] and x[4]
	fxch	st(3)								;	R		AE		CG		ae		S
	fld		st(2)
	fadd	st(0),	st(2)						;  AE+CG	R		AE		CG		ae		S
	fld		st(1)
	fld		st(1)								;  AE+CG	R	   AE+CG	R		AE		CG		ae		S
	faddp	st(3),	st(0)						;	R	   AE+CG	x[0]	AE		CG		ae		S
	fsubp										;	x[4]	x[0]	AE		CG		ae		S

	fld		quaver								;	1/8		x[4]	x[0]	AE		CG		ae		S
	fmul	st(2),	st(0)
	fmulp

	fstp	real8	ptr	[rcx + 32]				;	X[4]
	fstp	real8	ptr	[rcx]					;	X[0]
												

	fld		real8	ptr	[rdx + 72]
	fld		real8	ptr	[rdx + 120]
	fsubp
	fld		real8	ptr	[rdx + 88]
	fld		real8	ptr	[rdx + 104]
	fsubp

	;	P = b' - h' + d' - f'
	;	Q = b' - h' - (d' - f')
	fld		st(1)
	fld		st(1)
	faddp	st(3),	st(0)
	fsubp										;	Q		P		AE		CG		ae		S
	
	; Conjugating
	fchs
	fxch	st(1)
	fchs
	fxch	st(1)

	;	search of x[2] and x[6]
	fxch	st(3)								;	CG		P		AE		Q		ae		S
	fsubp	st(2),	st(0)						;	P	  AE-CG		Q		ae		S
	fxch	st(1)								;  AE-CG	P		Q		ae		S
	
	fld		st(2)
	fld		st(1)								;  AE-CG	Q	  AE-CG		P		Q		ae		S
	faddp	st(4),	st(0)						;    Q	  AE-CG		P	   x[2]		ae		S
	fsubp										;   x[2]	P	   x[6]		ae		S

	fld		quaver								;   1/8	   x[2]		P	   x[6]		ae		S
	fmul	st(3),	st(0)
	fmulp										;	x[2]	P	   x[6]		ae		S

	fstp	real8	ptr	[rcx + 16]				;	X[2]
	fxch
	fstp	real8	ptr	[rcx + 48]				;	X[6]
												;	P		ae		S

	;	search of x[1], x[3], x[5], x[7]
	fld		real8	ptr	[rdx + 80]
	fld		real8	ptr	[rdx + 112]
	fsubp										;	c'g'	P		ae		S

	;Conjugating
	fchs

	fld		_2
	fsqrt
	fdiv	_2									;	w	  c'g'		P		ae		S
	fmul	st(4),	st(0)
	fmulp	st(2),	st(0)						;	c'g'	wP		ae		wS
	
	fld		st(2)								
	fadd	st(0),	st(1)						;	ae+c'g'		c'g'	wP		ae		wS
	fld		st(2)								
	fadd	st(0),	st(5)						;	wP+wS		ae+c'g'		c'g'	wP		ae		wS
	fld		st(1)
	fld		st(1)								;	wP+wS		ae+c'g'		wP+wS		ae+c'g'		c'g'	wP		ae		wS
	fsubp	st(3),	st(0)
	faddp										;	x[1]		x[5]		c'g'	wP		ae		wS

	fld		quaver
	fmul	st(2),	st(0)
	fmulp
	
	fstp	real8	ptr	[rcx + 8]				;	X[1]
	fstp	real8	ptr	[rcx + 40]				;	X[5]

	fsubp	st(2),	st(0)						;	wP		ae-c'g'		wS
	fsubp	st(2),	st(0)						;	ae-c'g'			wS-wP
	fxch	st(1)								;	wS - wP		ae-c'g'
	fld		st(1)								
	fld		st(1)
	fsubp	st(3),	st(0)
	faddp										;	x[7]		x[3]

	fld		quaver
	fmul	st(2),	st(0)
	fmulp
	fstp	real8	ptr	[rcx + 56]				;	X[7]
	fstp	real8	ptr	[rcx + 24]				;	X[3]

	ret
RecoverSignal ENDP
END