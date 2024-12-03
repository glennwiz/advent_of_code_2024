package gnipahellir;

import "core:fmt"
import "core:io"
import "core:os"
import "core:slice"
import "core:strconv"
import "core:strings"

//odin Language
main :: proc() {
    fmt.println("---------")

    path := "C:/dev/advent_of_code_2024/data/20243"
    data, ok := os.read_entire_file(path, context.allocator)
    	if !ok {return}     

	defer delete(data, context.allocator)

    fmt.println("data:", string(data))      
    //regex find mul(num, num)   

}
