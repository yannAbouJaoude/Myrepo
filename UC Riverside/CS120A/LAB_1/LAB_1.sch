<?xml version="1.0" encoding="UTF-8"?>
<drawing version="7">
    <attr value="spartan3e" name="DeviceFamilyName">
        <trait delete="all:0" />
        <trait editname="all:0" />
        <trait edittrait="all:0" />
    </attr>
    <netlist>
        <signal name="XLXN_1" />
        <signal name="TOP_A" />
        <signal name="XLXN_9" />
        <signal name="XLXN_10" />
        <signal name="XLXN_11" />
        <signal name="XLXN_12" />
        <signal name="BOT_A" />
        <signal name="OUTPUT_AND" />
        <signal name="OUTPUT_NAND" />
        <signal name="OUTPUT_OR" />
        <signal name="OUTPUT_NOR" />
        <port polarity="Input" name="TOP_A" />
        <port polarity="Input" name="BOT_A" />
        <port polarity="Output" name="OUTPUT_AND" />
        <port polarity="Output" name="OUTPUT_NAND" />
        <port polarity="Output" name="OUTPUT_OR" />
        <port polarity="Output" name="OUTPUT_NOR" />
        <blockdef name="and2">
            <timestamp>2000-1-1T10:10:10</timestamp>
            <line x2="64" y1="-64" y2="-64" x1="0" />
            <line x2="64" y1="-128" y2="-128" x1="0" />
            <line x2="192" y1="-96" y2="-96" x1="256" />
            <arc ex="144" ey="-144" sx="144" sy="-48" r="48" cx="144" cy="-96" />
            <line x2="64" y1="-48" y2="-48" x1="144" />
            <line x2="144" y1="-144" y2="-144" x1="64" />
            <line x2="64" y1="-48" y2="-144" x1="64" />
        </blockdef>
        <blockdef name="nand2">
            <timestamp>2000-1-1T10:10:10</timestamp>
            <line x2="64" y1="-64" y2="-64" x1="0" />
            <line x2="64" y1="-128" y2="-128" x1="0" />
            <line x2="216" y1="-96" y2="-96" x1="256" />
            <circle r="12" cx="204" cy="-96" />
            <line x2="64" y1="-48" y2="-144" x1="64" />
            <line x2="144" y1="-144" y2="-144" x1="64" />
            <line x2="64" y1="-48" y2="-48" x1="144" />
            <arc ex="144" ey="-144" sx="144" sy="-48" r="48" cx="144" cy="-96" />
        </blockdef>
        <blockdef name="or2">
            <timestamp>2000-1-1T10:10:10</timestamp>
            <line x2="64" y1="-64" y2="-64" x1="0" />
            <line x2="64" y1="-128" y2="-128" x1="0" />
            <line x2="192" y1="-96" y2="-96" x1="256" />
            <arc ex="192" ey="-96" sx="112" sy="-48" r="88" cx="116" cy="-136" />
            <arc ex="48" ey="-144" sx="48" sy="-48" r="56" cx="16" cy="-96" />
            <line x2="48" y1="-144" y2="-144" x1="112" />
            <arc ex="112" ey="-144" sx="192" sy="-96" r="88" cx="116" cy="-56" />
            <line x2="48" y1="-48" y2="-48" x1="112" />
        </blockdef>
        <blockdef name="nor2">
            <timestamp>2000-1-1T10:10:10</timestamp>
            <line x2="64" y1="-64" y2="-64" x1="0" />
            <line x2="64" y1="-128" y2="-128" x1="0" />
            <line x2="216" y1="-96" y2="-96" x1="256" />
            <circle r="12" cx="204" cy="-96" />
            <arc ex="192" ey="-96" sx="112" sy="-48" r="88" cx="116" cy="-136" />
            <arc ex="112" ey="-144" sx="192" sy="-96" r="88" cx="116" cy="-56" />
            <arc ex="48" ey="-144" sx="48" sy="-48" r="56" cx="16" cy="-96" />
            <line x2="48" y1="-48" y2="-48" x1="112" />
            <line x2="48" y1="-144" y2="-144" x1="112" />
        </blockdef>
        <block symbolname="and2" name="XLXI_1">
            <blockpin signalname="BOT_A" name="I0" />
            <blockpin signalname="TOP_A" name="I1" />
            <blockpin signalname="OUTPUT_AND" name="O" />
        </block>
        <block symbolname="nand2" name="XLXI_2">
            <blockpin signalname="BOT_A" name="I0" />
            <blockpin signalname="TOP_A" name="I1" />
            <blockpin signalname="OUTPUT_NAND" name="O" />
        </block>
        <block symbolname="or2" name="XLXI_3">
            <blockpin signalname="BOT_A" name="I0" />
            <blockpin signalname="TOP_A" name="I1" />
            <blockpin signalname="OUTPUT_OR" name="O" />
        </block>
        <block symbolname="nor2" name="XLXI_4">
            <blockpin signalname="BOT_A" name="I0" />
            <blockpin signalname="TOP_A" name="I1" />
            <blockpin signalname="OUTPUT_NOR" name="O" />
        </block>
    </netlist>
    <sheet sheetnum="1" width="3520" height="2720">
        <instance x="432" y="400" name="XLXI_1" orien="R0" />
        <instance x="1056" y="400" name="XLXI_2" orien="R0" />
        <instance x="1696" y="416" name="XLXI_3" orien="R0" />
        <instance x="2320" y="384" name="XLXI_4" orien="R0" />
        <branch name="TOP_A">
            <wire x2="432" y1="144" y2="144" x1="304" />
            <wire x2="496" y1="144" y2="144" x1="432" />
            <wire x2="1040" y1="144" y2="144" x1="496" />
            <wire x2="1056" y1="144" y2="144" x1="1040" />
            <wire x2="1632" y1="144" y2="144" x1="1056" />
            <wire x2="1664" y1="144" y2="144" x1="1632" />
            <wire x2="1664" y1="144" y2="288" x1="1664" />
            <wire x2="1696" y1="288" y2="288" x1="1664" />
            <wire x2="2320" y1="144" y2="144" x1="1664" />
            <wire x2="2704" y1="144" y2="144" x1="2320" />
            <wire x2="1056" y1="144" y2="208" x1="1056" />
            <wire x2="432" y1="128" y2="128" x1="352" />
            <wire x2="432" y1="128" y2="144" x1="432" />
            <wire x2="352" y1="128" y2="272" x1="352" />
            <wire x2="432" y1="272" y2="272" x1="352" />
            <wire x2="1056" y1="208" y2="208" x1="1008" />
            <wire x2="1008" y1="208" y2="272" x1="1008" />
            <wire x2="1056" y1="272" y2="272" x1="1008" />
            <wire x2="2320" y1="128" y2="128" x1="2240" />
            <wire x2="2320" y1="128" y2="144" x1="2320" />
            <wire x2="2240" y1="128" y2="256" x1="2240" />
            <wire x2="2320" y1="256" y2="256" x1="2240" />
        </branch>
        <branch name="BOT_A">
            <wire x2="432" y1="544" y2="544" x1="336" />
            <wire x2="1056" y1="544" y2="544" x1="432" />
            <wire x2="1696" y1="544" y2="544" x1="1056" />
            <wire x2="2288" y1="544" y2="544" x1="1696" />
            <wire x2="2688" y1="544" y2="544" x1="2288" />
            <wire x2="432" y1="336" y2="336" x1="368" />
            <wire x2="368" y1="336" y2="416" x1="368" />
            <wire x2="432" y1="416" y2="416" x1="368" />
            <wire x2="432" y1="416" y2="544" x1="432" />
            <wire x2="1056" y1="336" y2="336" x1="992" />
            <wire x2="992" y1="336" y2="416" x1="992" />
            <wire x2="1056" y1="416" y2="416" x1="992" />
            <wire x2="1056" y1="416" y2="544" x1="1056" />
            <wire x2="1696" y1="352" y2="352" x1="1632" />
            <wire x2="1632" y1="352" y2="432" x1="1632" />
            <wire x2="1696" y1="432" y2="432" x1="1632" />
            <wire x2="1696" y1="432" y2="544" x1="1696" />
            <wire x2="2320" y1="320" y2="320" x1="2288" />
            <wire x2="2288" y1="320" y2="544" x1="2288" />
        </branch>
        <iomarker fontsize="28" x="304" y="144" name="TOP_A" orien="R180" />
        <iomarker fontsize="28" x="336" y="544" name="BOT_A" orien="R180" />
        <branch name="OUTPUT_AND">
            <wire x2="720" y1="304" y2="304" x1="688" />
        </branch>
        <iomarker fontsize="28" x="720" y="304" name="OUTPUT_AND" orien="R0" />
        <branch name="OUTPUT_NAND">
            <wire x2="1344" y1="304" y2="304" x1="1312" />
        </branch>
        <iomarker fontsize="28" x="1344" y="304" name="OUTPUT_NAND" orien="R0" />
        <branch name="OUTPUT_OR">
            <wire x2="1984" y1="320" y2="320" x1="1952" />
        </branch>
        <iomarker fontsize="28" x="1984" y="320" name="OUTPUT_OR" orien="R0" />
        <branch name="OUTPUT_NOR">
            <wire x2="2608" y1="288" y2="288" x1="2576" />
        </branch>
        <iomarker fontsize="28" x="2608" y="288" name="OUTPUT_NOR" orien="R0" />
    </sheet>
</drawing>