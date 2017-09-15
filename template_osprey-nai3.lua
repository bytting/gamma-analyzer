function gevalue (energy)
	if energy <= 0.09 then	
		return -22.609 * energy^3 + 5.3102 * energy^2 - 0.4109 * energy + 0.0112
	else	
		return -0.0005 * energy^5 + 0.0046 * energy^4 - 0.015 * energy^3 + 0.0197 * energy^2 + 0.0035 * energy + 0.0002
	end
end