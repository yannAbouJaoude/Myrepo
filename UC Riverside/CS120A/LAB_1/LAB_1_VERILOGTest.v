// Verilog test fixture created from schematic D:\Documents\Xilinx project\LAB_1\LAB_1.sch - Tue Oct 09 09:31:23 2018

`timescale 1ns / 1ps

module LAB_1_LAB_1_sch_tb();

// Inputs
   reg TOP_A;
   reg BOT_A;

// Output
   wire OUTPUT_AND;
   wire OUTPUT_NAND;
   wire OUTPUT_OR;
   wire OUTPUT_NOR;
	
// Clock definitions
	reg clk;

// Bidirs

// Instantiate the UUT
   LAB_1 UUT (
		.TOP_A(TOP_A), 
		.BOT_A(BOT_A), 
		.OUTPUT_AND(OUTPUT_AND), 
		.OUTPUT_NAND(OUTPUT_NAND), 
		.OUTPUT_OR(OUTPUT_OR), 
		.OUTPUT_NOR(OUTPUT_NOR)
   );
// Initialize Inputs
   /*`ifdef auto_init
       initial begin
		TOP_A = 0;
		BOT_A = 0;
   `endif*/
	
	initial begin
	clk = 0 ;
		forever begin
		#20 clk = ~clk;
		end
	end
	initial begin

#40 ;
BOT_A = 1'b1;
TOP_A = 1'b1;
#40 ; 
$display("TC1 ");
if ( {OUTPUT_AND,OUTPUT_NAND,OUTPUT_OR,OUTPUT_NOR} != 4'b1010 ) $display ("Result is wrong %b ", {OUTPUT_AND,OUTPUT_NAND,OUTPUT_OR,OUTPUT_NOR});
BOT_A = 1'b0;
TOP_A = 1'b0;
#40 ;
$display("TC2 ");
if ( {OUTPUT_AND,OUTPUT_NAND,OUTPUT_OR,OUTPUT_NOR} != 4'b0101 ) $display ("Result is wrong %b ", {OUTPUT_AND,OUTPUT_NAND,OUTPUT_OR,OUTPUT_NOR});
// Your own test cases 
end
endmodule
