package gnipahellir

import "core:fmt"
import "core:io"
import "core:os"
import "core:slice"
import "core:strconv"
import "core:strings"
import "core:text/regex"

//odin Language
main :: proc() {
	fmt.println("---------")

	path := "C:/dev/advent_of_code_2024/data/20243"
	data, ok := os.read_entire_file(path, context.allocator)
	if !ok {return}

	defer delete(data, context.allocator)

	fmt.println("data:", string(data))
	//regex find mul(num, num)   


	//https://pkg.odin-lang.org/core/text/regex/#create
	pattern := `mul\((\d+),\s*(\d+)\)`
	re, err := regex.create(pattern, {.Global})

	if err != nil {
		fmt.println("Error compiling regex:", err)
		return
	}
	defer regex.destroy_regex(re)
	the_sum := 0
	
	sub:= string(data)
	for mul in regex.match(re, string(sub)) {
		defer regex.destroy_capture(mul)
		fmt.println("--" , mul.groups[0]) // mul(123, 456)
		fmt.println(mul.pos[0][1]) 
		
		sub = sub[mul.pos[0][1]:]
		//fmt.println("sub:", sub))

		fmt.println("mul:", mul.groups[0]) // mul: mul(684,550)
		fmt.println("mul:", mul.groups[1]) // mul: 684
		fmt.println("mul:", mul.groups[2]) // mul: 550

		num1, e1:= strconv.parse_int(mul.groups[1]) 
		num2, e2:= strconv.parse_int(mul.groups[2])

		the_sum += num1 * num2

	}

	fmt.println(the_sum) // * 175615763 *
}
