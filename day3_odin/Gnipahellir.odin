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


	//https://pkg.odin-lang.org/core/text/regex/
	pattern := `mul\((\d+),(\d+)\)`
	re, err := regex.create(pattern)

	if err != nil {
		fmt.println("Error compiling regex:", err)
		return
	}
}
