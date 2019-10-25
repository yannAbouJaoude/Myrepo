--------------------------------------------------------------------------------
-- Copyright (c) 1995-2013 Xilinx, Inc.  All rights reserved.
--------------------------------------------------------------------------------
--   ____  ____ 
--  /   /\/   / 
-- /___/  \  /    Vendor: Xilinx 
-- \   \   \/     Version : 14.7
--  \   \         Application : sch2hdl
--  /   /         Filename : LAB_1.vhf
-- /___/   /\     Timestamp : 10/09/2018 09:44:52
-- \   \  /  \ 
--  \___\/\___\ 
--
--Command: sch2hdl -intstyle ise -family spartan3e -flat -suppress -vhdl "D:/Documents/Xilinx project/LAB_1/LAB_1.vhf" -w "D:/Documents/Xilinx project/LAB_1/LAB_1.sch"
--Design Name: LAB_1
--Device: spartan3e
--Purpose:
--    This vhdl netlist is translated from an ECS schematic. It can be 
--    synthesized and simulated, but it should not be modified. 
--

library ieee;
use ieee.std_logic_1164.ALL;
use ieee.numeric_std.ALL;
library UNISIM;
use UNISIM.Vcomponents.ALL;

entity LAB_1 is
   port ( BOT_A       : in    std_logic; 
          TOP_A       : in    std_logic; 
          OUTPUT_AND  : out   std_logic; 
          OUTPUT_NAND : out   std_logic; 
          OUTPUT_NOR  : out   std_logic; 
          OUTPUT_OR   : out   std_logic);
end LAB_1;

architecture BEHAVIORAL of LAB_1 is
   attribute BOX_TYPE   : string ;
   component AND2
      port ( I0 : in    std_logic; 
             I1 : in    std_logic; 
             O  : out   std_logic);
   end component;
   attribute BOX_TYPE of AND2 : component is "BLACK_BOX";
   
   component NAND2
      port ( I0 : in    std_logic; 
             I1 : in    std_logic; 
             O  : out   std_logic);
   end component;
   attribute BOX_TYPE of NAND2 : component is "BLACK_BOX";
   
   component OR2
      port ( I0 : in    std_logic; 
             I1 : in    std_logic; 
             O  : out   std_logic);
   end component;
   attribute BOX_TYPE of OR2 : component is "BLACK_BOX";
   
   component NOR2
      port ( I0 : in    std_logic; 
             I1 : in    std_logic; 
             O  : out   std_logic);
   end component;
   attribute BOX_TYPE of NOR2 : component is "BLACK_BOX";
   
begin
   XLXI_1 : AND2
      port map (I0=>BOT_A,
                I1=>TOP_A,
                O=>OUTPUT_AND);
   
   XLXI_2 : NAND2
      port map (I0=>BOT_A,
                I1=>TOP_A,
                O=>OUTPUT_NAND);
   
   XLXI_3 : OR2
      port map (I0=>BOT_A,
                I1=>TOP_A,
                O=>OUTPUT_OR);
   
   XLXI_4 : NOR2
      port map (I0=>BOT_A,
                I1=>TOP_A,
                O=>OUTPUT_NOR);
   
end BEHAVIORAL;


